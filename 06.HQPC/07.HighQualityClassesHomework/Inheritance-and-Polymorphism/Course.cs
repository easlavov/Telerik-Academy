namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public abstract class Course
    {
        private const int MIN_NAME_LENGTH = 2;
        private const int MAX_NAME_LENGTH = 20;
        private string name;
        private string teacherName;
        private IList<string> students;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null || value.Length < MIN_NAME_LENGTH || value.Length > MAX_NAME_LENGTH)
                {
                    string msg = string.Format("Course name should be between {0} and {1} cahracters long.",
                                                MIN_NAME_LENGTH,
                                                MAX_NAME_LENGTH);
                    throw new ArgumentException(msg);
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                if (value == null || value.Length < MIN_NAME_LENGTH || value.Length > MAX_NAME_LENGTH)
                {
                    string msg = string.Format("Teacher name should be between {0} and {1} cahracters long.",
                                                MIN_NAME_LENGTH,
                                                MAX_NAME_LENGTH);
                    throw new ArgumentException(msg);
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
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
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }
    }
}
