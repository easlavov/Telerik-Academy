namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents a course, held locally
    /// </summary>
    public class LocalCourse : Course
    {
        /// <summary>
        /// The default value of the lab name.
        /// </summary>
        private const string DEFAULT_LAB_NAME = "default lab";

        /// <summary>
        /// The minimum acceptable length of a name.
        /// </summary>
        private const int MIN_LAB_NAME_LENGTH = 1;

        /// <summary>
        /// The maximum acceptable length of a name.
        /// </summary>
        private const int MAX_LAB_NAME_LENGTH = 15;

        /// <summary>
        /// The course's lab name.
        /// </summary>
        private string lab;

        /// <summary>
        /// Initializes a new instance of the LocalCourse class.
        /// </summary>
        /// <param name="courseName">The course's name.</param>
        public LocalCourse(string courseName)
            : this(courseName, null, new List<string>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the LocalCourse class.
        /// </summary>
        /// <param name="courseName">The course's name.</param>
        /// <param name="teacherName">The course's teacher's name.</param>
        public LocalCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the LocalCourse class.
        /// </summary>
        /// <param name="courseName">The course's name.</param>
        /// <param name="teacherName">The course's teacher's name.</param>
        /// <param name="students">The list of student's names.</param>
        public LocalCourse(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
            this.Lab = DEFAULT_LAB_NAME;
        }

        /// <summary>
        /// Gets or sets the lab.
        /// </summary>
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

        /// <summary>
        /// An override to the ToString() method.
        /// </summary>
        /// <returns>A comprehensible string of a LocalCourse instance.</returns>
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
