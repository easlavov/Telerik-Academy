namespace _03.Cookies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Redirect : System.Web.UI.Page
    {
        private const string VALID_COOKIE_MESSAGE = "Your cookie is valid";

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var cookie = this.Request.Cookies["username"];
            if (cookie == null)
            {
                this.Response.Redirect("~/Login.aspx");
            }
            else
            {
                this.LabelStatus.Text = VALID_COOKIE_MESSAGE;
            }
        }
    }
}