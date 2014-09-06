namespace Bookstore.Data
{
    using System.Data.Entity;

    using Bookstore.Models;

    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext()
            : base("Bookstore")
        {            
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Review> Reviews { get; set; }
    }
}
