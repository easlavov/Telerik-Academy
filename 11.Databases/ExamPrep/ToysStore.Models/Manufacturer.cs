namespace ToysStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Toys = new HashSet<Toy>();
        }

        public int ID { get; set; }

        public Guid Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        public virtual ICollection<Toy> Toys { get; set; }
    }
}
