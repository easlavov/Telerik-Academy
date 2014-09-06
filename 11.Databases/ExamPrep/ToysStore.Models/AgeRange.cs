namespace ToysStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AgeRange
    {
        public int ID { get; set; }

        public int Lower { get; set; }

        public int Upper { get; set; }

        public virtual Toy Toy { get; set; }
    }
}
