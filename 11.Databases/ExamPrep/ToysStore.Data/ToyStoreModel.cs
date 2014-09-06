namespace ToysStore.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ToysStore.Models;

    public partial class ToyStoreModel : DbContext
    {
        public ToyStoreModel()
            : base("name=ToyStoreModel1")
        {
        }

        public virtual DbSet<AgeRange> AgeRanges { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Toy> Toys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeRange>()
                .HasMany(e => e.Toys)
                .WithOptional(e => e.AgeRanx)
                .HasForeignKey(e => e.AgeRangeID);

            modelBuilder.Entity<Manufacturer>()
                .HasMany(e => e.Toys)
                .WithRequired(e => e.Manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Toy>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
        }
    }
}
