namespace BullsAndCows.Services.Models
{
    using System;
    using System.Collections.Generic;

    using BullsAndCows.Models;

    public class GameDetailsDataModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string Red { get; set; }

        public string Blue { get; set; }

        public string YourNumber { get; set; }

        public ICollection<GuessDataModel> YourGuesses { get; set; }

        public ICollection<GuessDataModel> OpponentGuesses { get; set; }

        public string YourColor { get; set; }

        public GameState GameState { get; set; }
    }
}