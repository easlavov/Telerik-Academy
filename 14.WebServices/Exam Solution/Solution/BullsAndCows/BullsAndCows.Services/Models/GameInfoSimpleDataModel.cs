namespace BullsAndCows.Services.Models
{
    using System;
    using System.Linq.Expressions;

    using BullsAndCows.Models;

    public class GameInfoSimpleDataModel
    {
        private const string BLUE_PLAYER_NAME_NEW_GAME = "No blue player yet";

        public static Expression<Func<Game, GameInfoSimpleDataModel>> FromGame
        {
            get
            {
                return a => new GameInfoSimpleDataModel
                {                    
                    Id = a.Id,
                    Name = a.Name,
                    Blue = a.Blue != null ? a.Blue.UserName : BLUE_PLAYER_NAME_NEW_GAME,
                    Red = a.Red.UserName,
                    GameState = a.GameState.ToString(),
                    DateCreated = a.DateCreated
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }
    }
}