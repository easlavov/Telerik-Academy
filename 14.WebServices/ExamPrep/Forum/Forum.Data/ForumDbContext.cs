namespace Forum.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Forum.Models;
    using Forum.Data.Migrations;

    public class ForumDbContext : IdentityDbContext<User>
    {
        public ForumDbContext()
            : base("ForumConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumDbContext, Configuration>());
        }

        public static ForumDbContext Create()
        {
            return new ForumDbContext();
        }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<Category> Categories { get; set; }
    }
}
