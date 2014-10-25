namespace Countries.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Index(IsUnique=true)]
        public string Name { get; set; }

        public byte[] Flag { get; set; }
        
        [ForeignKey("Continent")]
        public int ContinentId { get; set; }

        [Required]
        public virtual Continent Continent { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        [Required]
        public virtual Language Language { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Population { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}
