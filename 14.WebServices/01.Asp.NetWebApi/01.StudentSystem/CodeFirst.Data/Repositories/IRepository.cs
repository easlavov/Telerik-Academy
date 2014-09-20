namespace CodeFirst.Data.Repositories
{
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        void Add(T entity);

        T Get(int id);

        void Remove(T entity);

        void Update(T entity);

        void Detach(T entity);

        void SaveChanges();
    }
}
