namespace _02.Codebehind
{
    using System;
    using System.Reflection;

    public partial class Index : System.Web.UI.Page
    {
        private const string MESSAGE = "This text is printed from the codebehind!";
        private const string LOCATION_PREFIX = "The current assembly location is ";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelCodebehind.Text = MESSAGE;
            this.LabelLocation.Text = LOCATION_PREFIX + Assembly.GetExecutingAssembly().Location;
        }
    }
}