namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Homework
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime TimeSent { get; set; }
    }
}
