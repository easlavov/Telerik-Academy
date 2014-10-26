namespace _02.AppendTextThroughSession
{
    using System;
    using System.Text;

    using _02.AppendTextThroughSession.Models;

    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
 

        protected void Page_PreRender(object sender, EventArgs e)
        {
            AppendFeedback();
            this.TextBoxInput.Text = string.Empty;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string userInput = this.TextBoxInput.Text;
            if (this.Session.Keys.Count > 0)
            {
                var data = this.Session["data"] as SessionData;
                data.Lines.Add(userInput);
            }
            else
            {
                var sessionData = new SessionData();
                sessionData.Lines.Add(userInput);
                this.Session["data"] = sessionData;
            }
        }

        private void AppendFeedback()
        {
            if (this.Session.Keys.Count > 0)
            {
                var data = this.Session["data"] as SessionData;
                var sb = new StringBuilder();
                foreach (var line in data.Lines)
                {
                    sb.AppendLine(line);
                }

                string feedback = this.Server.HtmlEncode(sb.ToString());
                this.LabelFeedback.Text = feedback;
            }
        }
    }
}