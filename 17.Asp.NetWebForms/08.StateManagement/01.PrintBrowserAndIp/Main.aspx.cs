namespace _01.PrintBrowserAndIp
{
    using System;

    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string browser = this.Request.Browser.Browser;
            string ip = this.Request.UserHostAddress;

            this.LiteralInfo.Text += "Your browser is " + browser + "<br />";
            this.LiteralInfo.Text += "Your IP address is " + ip;
        }
    }
}