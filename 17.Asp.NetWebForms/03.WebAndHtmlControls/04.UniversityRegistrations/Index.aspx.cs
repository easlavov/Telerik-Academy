namespace _04.UniversityRegistrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Index : System.Web.UI.Page
    {
        private string[] universities =
        {
            "Technical University",
            "Sofia University",
            "New Bulgarian University"
        };

        private string[] specialties =
        {
            "Biology",
            "Architecture",
            "Mathematics",
            "Computer Science"
        };

        private string[] courses = 
        {
            "C# Basics",
            "Chemistry",
            "Javascript Advanced"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.DropDownListUniversity.DataSource = universities;
                this.DropDownListSpecialty.DataSource = specialties;
                this.ListBoxCourses.DataSource = courses;

                this.DropDownListUniversity.DataBind();
                this.DropDownListSpecialty.DataBind();
                this.ListBoxCourses.DataBind();
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            AddNames();
            AddNumber();
            AddSpecialtyAndUniversity();
            AddCourses();
        }

        private void AddNames()
        {
            string firstName = this.TextBoxFirstName.Text;
            string lastName = this.TextBoxLastName.Text;

            var heading = new LiteralControl();
            heading.Text = "<h4>" + firstName + " " + lastName + "</h4>";
            this.PanelFeedback.Controls.Add(heading);
        }

        private void AddNumber()
        {
            string number = this.TextBoxFacultyNumber.Text;
            var facultyNumberField = new LiteralControl(
                                            "<span>" + number + "</span>" + "<br /><br />");

            this.PanelFeedback.Controls.Add(facultyNumberField);
        }

        private void AddSpecialtyAndUniversity()
        {
            string specialty = this.DropDownListSpecialty.SelectedItem.Text;
            string university = this.DropDownListUniversity.SelectedItem.Text;

            var specUniField = new LiteralControl(
                                        "<span>" + specialty + "</span>" + " in " + university + "<br />");

            this.PanelFeedback.Controls.Add(specUniField);
        }

        private void AddCourses()
        {
            var selectedCourses = this.ListBoxCourses.Items.OfType<ListItem>().Where(item => item.Selected);
            var coursesField = new LiteralControl("<p>Courses:</p>");
            foreach (var course in selectedCourses)
            {
                coursesField.Text += "<span>" + course + " | " + "</span>";
            }

            this.PanelFeedback.Controls.Add(coursesField);
        }
    }
}