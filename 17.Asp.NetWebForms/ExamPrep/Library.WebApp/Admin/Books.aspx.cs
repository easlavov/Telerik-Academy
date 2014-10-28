using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.WebApp.Admin
{
    public partial class Books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable ListViewCategories_GetData()
        {
            return null;
        }

        protected void Unnamed_Command(object sender, CommandEventArgs e)
        {

        }

        protected void Unnamed_Command1(object sender, CommandEventArgs e)
        {

        }
    }
}