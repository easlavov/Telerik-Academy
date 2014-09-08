namespace Company.Seeder
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class Seeder<T>  : ISeeder where T: class
    {
        private const int FLUSH_TRESHOLD = 100;
        private DbSet table;
        private IEnumerable<T> items;
        private DbContext context;

        public Seeder(DbSet<T> table, IEnumerable<T> items, DbContext context)
        {
            this.table = table;
            this.items = items;
            this.context = context;
        }

        public void Seed()
        {
            int counter = 0;
            foreach (var item in this.items)
            {
                this.table.Add(item);
                counter++;
                if (counter == FLUSH_TRESHOLD)
                {
                    context.SaveChanges();
                    Console.Write('.');
                    counter = 0;
                }
            }            

            context.SaveChanges();
        }
    }
}
