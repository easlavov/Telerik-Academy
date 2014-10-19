namespace _01.RandomGenerator
{
    using System;

    public partial class Index : System.Web.UI.Page
    {
        protected void ButtonGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                int from = int.Parse(this.TextBoxFrom.Value);
                int to = int.Parse(this.TextBoxTo.Value);
                var rndm = new Random();
                int number = rndm.Next(from, to + 1);
                this.LabelNumber.InnerText = number.ToString();
            }
            catch (Exception ex)
            {
                this.LabelNumber.InnerText = ex.Message;
            }
        }
    }
}