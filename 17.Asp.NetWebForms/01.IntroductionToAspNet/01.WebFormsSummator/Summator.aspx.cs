namespace _01.WebFormsSummator
{
    using System;

    public partial class Summator : System.Web.UI.Page
    {
        protected void ButtonSum_Click(object sender, EventArgs e)
        {
            try
            {
                double augend = double.Parse(this.TextBoxAugend.Text);
                double addend = double.Parse(this.TextBoxAddend.Text);
                double sum = augend + addend;

                this.TextBoxSum.Text = sum.ToString();
                this.TextBoxFeedback.Text = "Success!";  
            }
            catch (Exception ex)
            {
                this.TextBoxFeedback.Text = ex.Message;                
            }
        }
    }
}