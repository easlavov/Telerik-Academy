namespace _03.CustomHandler
{
    using System;
    using System.Text.RegularExpressions;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class _Default : Page
    {
        private const string ERROR_MESSAGE = "Only letters are allowed!";
        private const string ERROR_TEXTBOX_ID = "TextBoxError";

        public void ButtonImgRequest_Click(object sender, EventArgs e)
        {
            string text = this.TextBoxMessage.Text;
            if (TextIsValid(text))
            {
                string path = "/" + text + ".img";
                this.Response.Redirect(path);
            }
            //else
            //{
            //    var messageBox = this.FindControl(ERROR_TEXTBOX_ID);
            //    if (messageBox == null)
            //    {
            //        messageBox = new TextBox();
            //        messageBox.ID = ERROR_TEXTBOX_ID;
            //        this.Controls.Add(messageBox);
            //    }
            //    else
            //    {
            //        (messageBox as TextBox).Text = ERROR_MESSAGE;
            //    }
            //}            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private bool TextIsValid(string text)
        {
            var regex = new Regex("^[a-zA-Z]*$");
            if (regex.IsMatch(text))
            {
                return true;
            }

            return false;
        }
    }
}