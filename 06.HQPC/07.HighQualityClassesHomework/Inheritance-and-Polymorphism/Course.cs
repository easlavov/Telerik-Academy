namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    /// <summary>
    /// Represents an abstraction of an education course
    /// </summary>
    public abstract class Course
    {
        /// <summary>
        /// The minimum acceptable length of a name.
        /// </summary>
        private const int MIN_NAME_LENGTH = 2;

        /// <summary>
        /// The maximum acceptable length of a name.
        /// </summary>
        private const int MAX_NAME_LENGTH = 20;

        /// <summary>
        /// The name of the course.
        /// </summary>
        private string name;

        /// <summary>
        /// The name of the course's teacher
        /// </summary>
        private string teacherName;

        /// <summary>
        /// A list of the students names.
        /// </summary>
        private IList<string> students;

        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
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
                    string msg = string.Format(
                                        "Course name should be between {0} and {1} cahracters long.",
                                         MIN_NAME_LENGTH,
                                         MAX_NAME_LENGTH);
                    throw new ArgumentException(msg);
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the teacher's name.
        /// </summary>
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
                    string msg = string.Format(
                                        "Teacher name should be between {0} and {1} cahracters long.",
                                        MIN_NAME_LENGTH,
                                        MAX_NAME_LENGTH);
                    throw new ArgumentException(msg);
                }

                this.teacherName = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of student's names.
        /// </summary>
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

        /// <summary>
        /// An override to the ToString() method.
        /// </summary>
        /// <returns>A comprehensible string.</returns>
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

        /// <summary>
        /// Returns the student's names as strings.
        /// </summary>
        /// <returns>The student's names as strings.</returns>
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
    }
}
