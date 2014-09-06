using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysStore.Seeder
{
    public class Seeder<T>  : ISeeder where T: class
    {
        private DbSet table;
        private IEnumerable<T> items;

        public Seeder(DbSet<T> table, IEnumerable<T> items)
        {
            this.table = table;
            this.items = items;
        }

        public void Seed()
        {
            foreach (var item in this.items)
            {
                this.table.Add(item);
            }
        }
    }
}
