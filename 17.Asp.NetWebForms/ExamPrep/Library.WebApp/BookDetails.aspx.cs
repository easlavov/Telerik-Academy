namespace Library.WebApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.ModelBinding;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public object FormViewBook_GetItem([QueryString("id")]int id)
        {
            //int id = int.Parse(this.Request.QueryString["id"]);
            var context = new LibraryEntities();
            var book = context.Books.Find(id);
            if (book == null)
            {
                this.Response.Redirect("~/");
            }

            return book;
            //this.FormViewBook.DataSource = book;
            //this.FormViewBook.DataBind();
        }
    }
}