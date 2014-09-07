namespace Bookstore.XML
{
    using Bookstore.Data;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Bookstore.Models;
    using System.Xml;
    using System.Globalization;

    public class XmlImporter
    {
        private const string DATE_FORMAT = "d-MMM-yyyy";
        private const string INVALID_BOOK_ATTRIBUTES_MESSAGE = "Can't add book with missing attributes!";
        private string path;
        private BookstoreDbContext context;

        public XmlImporter(string filePath, BookstoreDbContext context)
        {
            this.path = filePath;
            this.context = context;
        }

        public void Import()
        {
            var reader = XmlReader.Create(this.path);
            using (reader)
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement() && reader.Name == "book")
                    {
                        try
                        {
                            var book = ParseBook(reader);
                            if (ValidateBook(book))
                            {
                                this.context.Books.Add(book);
                                context.SaveChanges();
                            }
                            else
                            {
                                throw new InvalidOperationException(INVALID_BOOK_ATTRIBUTES_MESSAGE);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }                        
                    }
                }
            }
        }

        private Book ParseBook(XmlReader reader)
        {
            var book = new Book();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                {
                    string title = reader.ReadInnerXml();
                    book.Title = title;
                }

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "web-site")
                {
                    string webSite = reader.ReadInnerXml();
                    book.Url = webSite;
                }

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "isbn")
                {
                    var isbn = new ISBN();
                    isbn.Value = reader.ReadInnerXml();
                    book.Isbn = isbn;
                }

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "authors")
                {
                    var authors = GetAuthors(reader); // could be empty
                    foreach (var author in authors)
                    {
                        book.Authors.Add(author);
                    }
                }

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "reviews")
                {
                    var reviews = GetReviews(reader); // could be empty
                    foreach (var review in reviews)
                    {
                        book.Reviews.Add(review);
                    }
                }

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "price")
                {
                    decimal price;
                    if (decimal.TryParse(reader.ReadInnerXml(), out price))
                    {
                        book.Price = price;
                    }
                    else
                    {
                        book.Price = null;
                    }
                }

                if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "book")
                {
                    break;
                }
            }

            return book;
        }

        private ICollection<Author> GetAuthors(XmlReader reader)
        {
            var authors = new List<Author>();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "author")
                {
                    string authorName = reader.ReadInnerXml();
                    var author = GetAuthor(authorName);
                    authors.Add(author);
                }

                if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "authors")
                {
                    break;
                }
            }

            return authors;
        }

        private Author GetAuthor(string authorName)
        {
            int isPresent = this.context.Authors.Count(auth => auth.Name == authorName);
            if (isPresent == 1)
            {
                return this.context.Authors.First(auth => auth.Name == authorName);
            }

            var newAuthor = new Author();
            newAuthor.Name = authorName;
            this.context.Authors.Add(newAuthor);
            return newAuthor;
        }

        private ICollection<Review> GetReviews(XmlReader reader)
        {
            var reviews = new List<Review>();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "review")
                {
                    var review = GetReview(reader);
                    reviews.Add(review);
                }

                if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "reviews")
                {
                    break;
                }
            }

            return reviews;
        }

        private Review GetReview(XmlReader reader)
        {
            var review = new Review();

            // Get attributes
            if (reader.HasAttributes)
            {
                string author = reader.GetAttribute("author");
                string date = reader.GetAttribute("date");

                if (!string.IsNullOrEmpty(author))
                {
                    review.Author = GetAuthor(author);
                }

                if (!string.IsNullOrEmpty(date))
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    var dateParsed = DateTime.ParseExact(date, DATE_FORMAT, provider);
                    review.Date = dateParsed;
                }
                else
                {
                    review.Date = DateTime.Now;
                }
            }

            // Get text
            string text = reader.ReadInnerXml().Trim();
            review.Text = text;

            return review;
        }

        private bool ValidateBook(Book book)
        {
            if (string.IsNullOrEmpty(book.Title))
            {
                return false;
            }

            if (book.Authors.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}
