namespace Library.WebApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new LibraryEntities();
            var categories = context.Categories.Include("Books").ToList();
            this.ListViewBooks.DataSource = categories;
            this.ListViewBooks.DataBind();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string keyword = this.TextBoxSearch.Text;
            this.Response.Redirect("~/Search.aspx?keyword=" + keyword);
        }
    }
}