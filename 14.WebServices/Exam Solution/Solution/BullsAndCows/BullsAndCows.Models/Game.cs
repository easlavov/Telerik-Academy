namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public Game()
        {
            this.RedPlayerGuesses = new HashSet<Guess>();
            this.BluePlayerGuesses = new HashSet<Guess>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public GameState GameState { get; set; }

        public string RedId { get; set; }

        public virtual User Red { get; set; }

        public string BlueId { get; set; }

        public virtual User Blue { get; set; }

        public DateTime DateCreated { get; set; }

        public string RedPlayerNumber { get; set; }

        public string BluePlayerNumber { get; set; }

        public virtual ICollection<Guess> RedPlayerGuesses { get; set; }

        public virtual ICollection<Guess> BluePlayerGuesses { get; set; }
    }
}
