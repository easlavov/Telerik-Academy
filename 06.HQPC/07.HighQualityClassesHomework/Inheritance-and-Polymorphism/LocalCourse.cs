namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private const string DEFAULT_LAB_NAME = "default lab";
        private const int MIN_LAB_NAME_LENGTH = 1;
        private const int MAX_LAB_NAME_LENGTH = 15;
        private string lab;

        public LocalCourse(string courseName)
            : this(courseName, null, new List<string>())
        {
        }

        public LocalCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
            this.Lab = DEFAULT_LAB_NAME;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (value == null || value.Length < MIN_LAB_NAME_LENGTH || value.Length > MAX_LAB_NAME_LENGTH)
                {
                    string msg = string.Format("Lab name should be between {0} and {1} cahracters long.",
                                                MIN_LAB_NAME_LENGTH,
                                                MAX_LAB_NAME_LENGTH);
                    throw new ArgumentException(msg);
                }

                this.lab = value;
            }
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { Name = ");
            
            result.Append(base.ToString());

            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
