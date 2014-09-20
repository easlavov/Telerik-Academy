namespace CodeFirst.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using CodeFirst.Models;

    public interface IForumDbContext
    {
        DbSet<Category> Categories { get; set; }

        DbSet<Post> Posts { get; set; }

        DbSet<PostAnswer> PostAnswers { get; set; }

        DbSet<Tag> Tags { get; set; }

        void SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
