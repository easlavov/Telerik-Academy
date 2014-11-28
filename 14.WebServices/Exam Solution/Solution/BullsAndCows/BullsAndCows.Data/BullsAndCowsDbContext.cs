namespace BullsAndCows.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using BullsAndCows.Models;
    using BullsAndCows.Data.Migrations;

    public class BullsAndCowsDbContext : IdentityDbContext<User>
    {
        public BullsAndCowsDbContext()
            : base("BullsAndCowsConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext, Configuration>());
        }

        public static BullsAndCowsDbContext Create()
        {
            return new BullsAndCowsDbContext();
        }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Guess> Guesses { get; set; }
    }
}
