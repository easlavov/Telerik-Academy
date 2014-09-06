namespace Bookstore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        private ICollection<Review> reviews;
        private ICollection<Author> authors;

        public Book()
        {
            this.reviews = new HashSet<Review>();
            this.authors = new HashSet<Author>();
        }

        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        public virtual ICollection<Author> Authors
        {
            get
            {
                return this.authors;
            }

            set
            {
                this.authors = value;
            }
        }

        public ISBN Isbn { get; set; }

        [Required]
        public decimal? Price { get; set; }

        public string Url { get; set; }

        public virtual ICollection<Review> Reviews 
        { 
            get
            {
                return this.reviews;
            }

            set
            {
                this.reviews = value;
            }
        }
    }
}
