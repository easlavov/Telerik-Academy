using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace StudentSystem.Models
{
    using System.Linq;

    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        public string Number { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homework { get; set; }
    }
}
