namespace _03.Cookies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = this.TextBoxUsername.Text;
            var cookie = new HttpCookie("username", username);
            cookie.Expires = DateTime.Now.AddMinutes(1);
            this.Response.Cookies.Add(cookie);
            this.Response.Redirect("~/Redirect.aspx");
        }
    }
}