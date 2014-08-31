using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace StudentSystem.Models
{
    using System.Linq;

    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(60)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Homework> Homework { get; set; }
    }
}
