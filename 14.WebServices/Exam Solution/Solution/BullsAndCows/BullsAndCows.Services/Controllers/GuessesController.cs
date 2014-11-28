namespace BullsAndCows.Services.Controllers
{    
    using System;
    using System.Linq;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.Services.Models;

    [Authorize]
    public class GuessesController : BaseApiController
    {
        public GuessesController(IBullsAndCowsData data)
            : base(data)
        {
        }

        [HttpPost]
        [Route("api/games/{id}/guess")]
        public IHttpActionResult Create(int id, SimpleNumberDataModel model)
        {
            if (!this.ModelState.IsValid || model.Number.Length != 4)
            {
                return this.BadRequest("Invalid model");
            }

            var game = this.data.Games.All().FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return this.BadRequest("Game doesn't exist");
            }

            // Check if game is not finished
            if (game.GameState == GameState.Complete)
            {
                return this.BadRequest("Game is already complete.");
            }

            string playerId = this.User.Identity.GetUserId();

            // Check if player is part of this game
            if (!(game.RedId == playerId
                || game.BlueId == playerId))
            {
                return this.BadRequest("You aren't a player in this game!");
            }

            bool isRed = true;
            bool canPlay = false;
            string numberCurrentPlayerHasToGuess = string.Empty;

            // Check if it's the players turn
            if (game.GameState == GameState.RedInTurn
                && game.RedId == playerId)
            {
                canPlay = true;
                numberCurrentPlayerHasToGuess = game.BluePlayerNumber;
            }
            else if(game.GameState == GameState.BlueInTurn
                && game.BlueId == playerId)
            {
                isRed = false;
                canPlay = true;
                numberCurrentPlayerHasToGuess = game.RedPlayerNumber;
            }

            if (!canPlay)
            {
                return this.BadRequest("It's not your turn!");
            }

            int[] bullsAndCows = FindBullsAndCows(model.Number, numberCurrentPlayerHasToGuess);
            int bulls = bullsAndCows[0];
            int cows = bullsAndCows[1];

            var guess = new Guess();
            guess.BullsCount = bulls;
            guess.CowsCount = cows;
            guess.DateMade = DateTime.Now;
            guess.Game = game;
            guess.GameId = game.Id;
            guess.Number = model.Number;
            guess.User = this.data.Users.All().FirstOrDefault(u => u.Id == playerId);
            guess.UserId = playerId;

            // Check if game is complete and if not - change to next player
            if (bulls == 4)
            {
                game.GameState = GameState.Complete;
                if (isRed)
                {
                    game.Red.Wins++;
                    game.Blue.Losses++;
                }
                else
                {
                    game.Red.Losses++;
                    game.Blue.Wins++;
                }
            }
            else
            {
                if (isRed)
                {
                    game.GameState = GameState.BlueInTurn;
                }
                else
                {
                    game.GameState = GameState.RedInTurn;
                }
            }

            // Add guess ot the corresponding list in the game
            if (isRed)
            {
                game.RedPlayerGuesses.Add(guess);
            }
            else
            {
                game.BluePlayerGuesses.Add(guess);
            }

            this.data.Guesses.Add(guess);
            this.data.SaveChanges();            

            var response = new GuessDataModel();
            response.BullsCount = guess.BullsCount;
            response.CowsCount = guess.CowsCount;
            response.DateMade = guess.DateMade;
            response.GameId = guess.GameId;
            response.Id = guess.Id;
            response.Number = guess.Number;
            response.UserId = guess.UserId;
            response.User = guess.User.UserName;

            return this.Ok(response);
        }

        public int[] FindBullsAndCows(string numberToSearch, string originalNumber)
        {
            int bulls = 0;
            int cows = 0;
            char[] currentNumber = new char[4];
            for (int i = 0; i < 4; i++)
            {
                currentNumber[i] = originalNumber[i];
            }

            for (int i = 0; i < 4; i++)
            {
                if (currentNumber[i] == numberToSearch[i])
                {
                    bulls++;
                    currentNumber[i] = 'a';
                }
            }
            
            for (int i = 0; i < 4; i++)
            {
                if (currentNumber.Contains(numberToSearch[i]) == true)
                {
                    int index = Array.IndexOf(currentNumber, numberToSearch[i]);
                    cows++;
                    currentNumber[index] = 'a';
                }
            }
                        
            int[] result = new int[2];
            result[0] = bulls;
            result[1] = cows;

            return result;
        }
    }
}
