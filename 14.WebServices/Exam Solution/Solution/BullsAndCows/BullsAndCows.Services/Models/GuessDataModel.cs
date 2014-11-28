namespace BullsAndCows.Services.Models
{
    using System;

    public class GuessDataModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }

        public int GameId { get; set; }

        public string Number { get; set; }

        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}