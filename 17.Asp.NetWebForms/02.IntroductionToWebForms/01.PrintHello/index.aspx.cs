namespace _01.PrintHello
{
    using System;

    public partial class Index : System.Web.UI.Page
    {
        private const string HELLO = "Hello, ";

        public void ButtonGreet_Click(object sender, EventArgs e)
        {
            string name = this.TextBoxName.Text;
            string text = HELLO + name;
            this.LabelGreeting.Text = text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}