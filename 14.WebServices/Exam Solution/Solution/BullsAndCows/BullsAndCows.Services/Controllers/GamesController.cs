namespace BullsAndCows.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    
    using Microsoft.AspNet.Identity;

    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.Services.Models;

    [Authorize]
    public class GamesController : BaseApiController
    {
        private const int GAMES_PER_PAGE = 10;
        private const string BLUE_PLAYER_NAME_NEW_GAME = "No blue player yet";
        private const string NEWLY_CREATED_STATE = "WaitingForOpponent";

        public GamesController(IBullsAndCowsData data)
            : base(data)
        {
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult All()
        {
            return this.All(0);
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult All(int page)
        {
            IQueryable<Game> games;
            // Unauthenticated user gets only certain games
            if (!this.User.Identity.IsAuthenticated)
            {
                games = this.data.Games.All()
                    .Where(g => g.GameState == GameState.WaitingForOpponent);
            }
            else
            {
                // Authenticated users get open games and games they're part of
                string userId = this.User.Identity.GetUserId();
                games = this.data.Games.All()
                            .Where(g => g.GameState == GameState.WaitingForOpponent ||
                                        ((g.RedId == userId || g.BlueId == userId) &&
                                         g.GameState != GameState.Complete));
            }

            var sorted = GetSortedGames(games)
                                .Skip(GAMES_PER_PAGE * page)
                                .Take(GAMES_PER_PAGE)
                                .Select(GameInfoSimpleDataModel.FromGame);

            return this.Ok(sorted);
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var game = this.data.Games.All().FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return this.BadRequest("Game doesn't exist!");
            }

            string userId = this.User.Identity.GetUserId();

            // Check if player is part of this game
            if (!(game.RedId == userId
                || game.BlueId == userId))
            {
                return this.BadRequest("You aren't a player in this game!");
            }

            bool isRed = true;
            string color = string.Empty;
            string numberOfCurrentPlayer = string.Empty;
            // Check the player color and number
            if (game.RedId == userId)
            {
                numberOfCurrentPlayer = game.RedPlayerNumber;
                color = "red";
            }
            else if (game.BlueId == userId)
            {
                isRed = false;
                numberOfCurrentPlayer = game.BluePlayerNumber;
                color = "blue";
            }

            var gameDetails = new GameDetailsDataModel();
            gameDetails.Id = game.Id;
            gameDetails.Name = game.Name;
            gameDetails.DateCreated = game.DateCreated;
            gameDetails.Red = game.Red.UserName;
            gameDetails.Blue = game.Blue.UserName;
            gameDetails.YourNumber = numberOfCurrentPlayer;
            gameDetails.YourGuesses = GetOwnGuesses(isRed, game);
            gameDetails.OpponentGuesses = GetOpponentGuesses(isRed, game);
            gameDetails.YourColor = color;
            gameDetails.GameState = game.GameState;

            return this.Ok(gameDetails);
        }

        private ICollection<GuessDataModel> GetOpponentGuesses(bool isRed, Game game)
        {
            if (isRed)
            {
                return GetGuesses(game.BluePlayerGuesses);
            }
            else
            {
                return GetGuesses(game.RedPlayerGuesses);
            }
        }

        private ICollection<GuessDataModel> GetOwnGuesses(bool isRed, Game game)
        {
            if (isRed)
            {
                return GetGuesses(game.RedPlayerGuesses);
            }
            else
            {
                return GetGuesses(game.BluePlayerGuesses);
            }
        } 

        [Authorize]
        [HttpPost]
        public IHttpActionResult Create(GameCreationDataModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid model");
            }

            if (!NumberIsValid(model.Number))
            {
                return this.BadRequest("Number is either not 4 characters or has duplicate digits.");
            }

            string userId = this.User.Identity.GetUserId();

            var game = new Game();
            game.Name = model.Name;
            game.GameState = GameState.WaitingForOpponent;
            game.RedPlayerNumber = model.Number;
            game.RedId = userId;
            game.Red = this.data.Users.All().FirstOrDefault(u => u.Id == userId);
            game.DateCreated = DateTime.Now;

            this.data.Games.Add(game);
            this.data.SaveChanges();

            var gameInfoSimple = new GameInfoSimpleDataModel();
            gameInfoSimple.Id = game.Id;
            gameInfoSimple.Name = game.Name;
            gameInfoSimple.Red = game.Red.UserName;
            gameInfoSimple.Blue = BLUE_PLAYER_NAME_NEW_GAME;
            gameInfoSimple.GameState = NEWLY_CREATED_STATE;
            gameInfoSimple.DateCreated = game.DateCreated;

            return this.Ok(gameInfoSimple);
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult Join(int id, SimpleNumberDataModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid data model sent");
            }

            if (!NumberIsValid(model.Number))
            {
                return this.BadRequest("Number is either not 4 characters or has duplicate digits.");
            }

            var game = this.data.Games.All().FirstOrDefault(g => g.Id == id);
            var userId = this.User.Identity.GetUserId();

            // Can't join a non-existent game
            if (game == null)
            {
                return this.BadRequest("Game doesn't exist.");
            }

            // Can't join a game with two players or completed
            if (game.GameState != GameState.WaitingForOpponent)
            {
                return this.BadRequest("Game can't e joined.");
            }

            // Can't join own game
            if (userId == game.RedId)
            {
                return this.BadRequest("Can't join own game.");
            }

            game.BlueId = userId;
            game.Blue = this.data.Users.All().FirstOrDefault(u => u.Id == userId);
            game.BluePlayerNumber = model.Number;

            // Decide first player
            var rnd = new Random();
            int roll = rnd.Next(1, 3);
            if (roll == 1)
            {
                game.GameState = GameState.RedInTurn;
            }
            else
            {
                game.GameState = GameState.BlueInTurn;
            }

            this.data.SaveChanges();

            var result = new
            {
                result = string.Format("You joined game \"{0}\"", game.Name)
            };

            return this.Ok(result);
        }

        private IQueryable<Game> GetSortedGames(IQueryable<Game> games)
        {
            var sorted = games.OrderBy(g => g.GameState)
                              .ThenBy(g => g.Name)
                              .ThenBy(g => g.DateCreated)
                              .ThenBy(g => g.Red.UserName);
            return sorted;
        }


        private bool NumberIsValid(string number)
        {
            if (number.Length != 4)
            {
                return false;
            }

            string checkUp = string.Empty;
            for (int i = 0; i < number.Length; i++)
            {
                if (checkUp.Contains(number[i]))
                {
                    return false;
                }

                checkUp += number[i];
            }

            return true;
        }

        private ICollection<GuessDataModel> GetGuesses(ICollection<Guess> playerGuesses)
        {
            HashSet<GuessDataModel> guesses = new HashSet<GuessDataModel>();
            foreach (var guess in playerGuesses)
            {
                guesses.Add(new GuessDataModel()
                {
                    Id = guess.Id,
                    UserId = guess.UserId,
                    User = guess.User.UserName,
                    GameId = guess.GameId,
                    Number = guess.Number,
                    DateMade = guess.DateMade,
                    CowsCount = guess.CowsCount,
                    BullsCount = guess.BullsCount
                });
            }

            return guesses;
        }
    }
}
