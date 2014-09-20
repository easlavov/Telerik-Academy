namespace AspNetWebApi.Models
{
    using CodeFirst.Data.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MemoryRepository<T> : IRepository<T> where T : class 
    {
        private readonly IList<T> items = new List<T>(); 

        public IQueryable<T> All()
        {
            return this.items.AsQueryable();
        }

        public T Get(int id)
        {
            return this.items[id];
        }

        public void Remove(T entity)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void Detach(T entity)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            this.items.Add(item);
        }

        public void Delete(int id)
        {
            this.items.RemoveAt(id);
        }

        public void Update(int id, T item)
        {
            if (this.items.Count <= id)
            {
                throw new IndexOutOfRangeException();
            }

            this.items[id] = item;
        }
    }
}