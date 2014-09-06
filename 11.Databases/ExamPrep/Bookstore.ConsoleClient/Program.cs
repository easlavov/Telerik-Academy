namespace Bookstore.ConsoleClient
{
    using Bookstore.Data;
    using Bookstore.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var bookstore = new BookstoreDbContext();

            bookstore.Authors.Any();

            bookstore.Authors.Add(new Author
            {
                Name = "Karavelov"
            });

            bookstore.SaveChanges();
        }
    }
}
