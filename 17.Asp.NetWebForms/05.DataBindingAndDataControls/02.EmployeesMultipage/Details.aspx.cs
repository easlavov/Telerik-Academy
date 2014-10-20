namespace _02.EmployeesMultipage
{
    using Northwind.Data;
    using System;
    using System.Linq;

    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(this.Request.QueryString.Get("id"));
            var db = new NorthwindEntities();
            var employee = db.Employees.Where(emp => emp.EmployeeID == id).ToList(); // hack
            this.DetailsViewEmployee.DataSource = employee;
            this.DetailsViewEmployee.DataBind();
        }
    }
}