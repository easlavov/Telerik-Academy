namespace _02.EmployeesMultipage
{
    using Northwind.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var db = new NorthwindEntities();
                var emps = db.Employees.ToList();
                this.FormViewEmployees.DataSource = emps;
                this.FormViewEmployees.DataBind();
            }
        }

        protected void FormViewEmployees_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            var db = new NorthwindEntities();
            var emps = db.Employees.ToList();
            this.FormViewEmployees.PageIndex = e.NewPageIndex;
            this.FormViewEmployees.DataSource = emps;
            this.FormViewEmployees.DataBind();
        }
    }
}