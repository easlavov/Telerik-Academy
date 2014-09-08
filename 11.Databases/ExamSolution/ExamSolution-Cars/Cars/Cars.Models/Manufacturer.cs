namespace Cars.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Manufacturer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }
    }
}
