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
            : base("name=ToyStoreModel")
        {
        }

        public virtual DbSet<AgeRange> AgeRanges { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Toy> Toys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>()
                .HasMany(e => e.Toys)
                .WithRequired(e => e.Manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Toy>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Toy>()
                .HasOptional(e => e.AgeRanx)
                .WithRequired(e => e.Toy);
        }
    }
}
