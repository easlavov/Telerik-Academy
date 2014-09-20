namespace CodeFirst.Data
{
    using System;
    using System.Data.Entity;
    using CodeFirst.Models;

    public class ForumDbContext : DbContext, IForumDbContext
    {
        public ForumDbContext()
            : base("ForumDb")
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostAnswer> PostAnswers { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasKey(x => x.TagId);
            modelBuilder.Entity<Tag>().Property(x => x.Text).IsUnicode(true);
            modelBuilder.Entity<Tag>().Property(x => x.Text).HasMaxLength(255);
            //// modelBuilder.Entity<Tag>().Property(x => x.Text).IsFixedLength();

            //// modelBuilder.Configurations.Add(new TagMappings());

            base.OnModelCreating(modelBuilder);
        }

        public new void SaveChanges()
        {
            this.SaveChanges();
        }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
