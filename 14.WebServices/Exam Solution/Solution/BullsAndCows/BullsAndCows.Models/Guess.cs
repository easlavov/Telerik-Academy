namespace BullsAndCows.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Guess
    {
        private const int NUM_LENGTH = 4;

        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        [MinLength(NUM_LENGTH)]
        [MaxLength(NUM_LENGTH)]
        public string Number { get; set; }

        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}
