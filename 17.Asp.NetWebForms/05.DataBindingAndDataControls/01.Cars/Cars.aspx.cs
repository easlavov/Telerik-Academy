namespace _01.Cars
{
    using _01.Cars.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Cars : System.Web.UI.Page
    {
        private static ICollection<Producer> producers;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadProducers();
                Bind();
            }
        }

        private void Bind()
        {
            this.DropDownListProducer.DataSource = producers;
            this.DropDownListProducer.DataBind();

            this.DropDownListModel.DataSource = producers.First(p => p.Name == "Dacia").Models;
            this.DropDownListModel.DataBind();

            this.CheckBoxListExtras.DataSource = Enumeration.GetAll<Extras>();
            this.CheckBoxListExtras.DataBind();

            this.RadioButtonListEngine.DataSource = Enumeration.GetAll<Engine>();
            this.RadioButtonListEngine.DataBind();
        }
 
        private void LoadProducers()
        {
            var dacia = new Producer();
            dacia.Name = "Dacia";
            dacia.Models = new HashSet<string>
            {
                "Sandero",
                "Duster"
            };

            var audi = new Producer();
            audi.Name = "Audi";
            audi.Models = new HashSet<string>
            {
                "A4",
                "A6",
                "A8"
            };

            producers = new HashSet<Producer>();
            producers.Add(dacia);
            producers.Add(audi);
        }

        protected void DropDownListProducer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedModel = this.DropDownListProducer.SelectedItem.Text;
            this.DropDownListModel.DataSource = producers.First(p => p.Name == selectedModel).Models;
            this.DropDownListModel.DataBind();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string producer = this.DropDownListProducer.SelectedItem.Text;
            string model = this.DropDownListModel.SelectedItem.Text;
            var extras = this.CheckBoxListExtras.Items.Cast<ListItem>().Where(it => it.Selected);
            var engine = this.RadioButtonListEngine.SelectedItem.Text;

            this.LiteralFeedback.Text = "";
            this.LiteralFeedback.Text += producer + "<br />";
            this.LiteralFeedback.Text += model + "<br />";
            foreach (var extra in extras)
            {
                this.LiteralFeedback.Text += extra + " | ";
            }

            this.LiteralFeedback.Text += "<br />" + engine;
        }
    }
}