namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        private const string DEFAULT_TOWN_NAME = "default town";
        private string town;

        public OffsiteCourse(string courseName)
            : this(courseName, null, new List<string>())
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
            this.Town = DEFAULT_TOWN_NAME;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (value == null || value.Length <= 1)
                {
                    throw new ArgumentException("Town name should be at least two characters.");
                }

                this.town = value;
            }
        }        

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { Name = ");

            result.Append(base.ToString());

            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
