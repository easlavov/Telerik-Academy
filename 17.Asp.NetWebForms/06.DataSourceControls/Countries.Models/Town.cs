namespace Countries.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Town
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [Required]
        public virtual Country Country { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Population { get; set; }
    }
}
