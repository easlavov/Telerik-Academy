namespace BullsAndCows.Data
{
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public interface IBullsAndCowsData
    {
        IRepository<Game> Games { get; }

        IRepository<Guess> Guesses { get; }

        IRepository<User> Users { get; }

        int SaveChanges();
    }
}
