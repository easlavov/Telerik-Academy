namespace _01.RandomGenerator
{
    using System;

    public partial class Index : System.Web.UI.Page
    {
        protected void ButtonGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                int from = int.Parse(this.TextBoxFrom.Text);
                int to = int.Parse(this.TextBoxTo.Text);
                var rndm = new Random();
                int number = rndm.Next(from, to + 1);
                this.LabelNumber.Text = number.ToString();
            }
            catch (Exception ex)
            {
                this.LabelNumber.Text = ex.Message;
            }
        }
    }
}