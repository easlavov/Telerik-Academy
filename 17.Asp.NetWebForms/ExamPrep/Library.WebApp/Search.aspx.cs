namespace Library.WebApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string keyword = this.Request.QueryString["keyword"];
            var context = new LibraryEntities();
            IList<Book> books;
            if (string.IsNullOrEmpty(keyword))
            {
                books = context.Books.ToList();
            }
            else
            {
                keyword = keyword.ToLower();
                books = context.Books
                .Where(
                    book =>
                           book.Title.ToLower().Contains(keyword) ||
                           book.Author.ToLower().Contains(keyword))
                .OrderBy(book => book.Title)
                .ToList();
            }
            
            this.RepeaterBooks.DataSource = books;
            this.RepeaterBooks.DataBind();
        }
    }
}