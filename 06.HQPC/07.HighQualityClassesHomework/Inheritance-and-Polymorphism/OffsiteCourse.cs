namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents a non-local course
    /// </summary>
    public class OffsiteCourse : Course
    {
        /// <summary>
        /// The default value of the town's name.
        /// </summary>
        private const string DEFAULT_TOWN_NAME = "default town";

        /// <summary>
        /// The town where the course is held.
        /// </summary>
        private string town;

        /// <summary>
        /// Initializes a new instance of the OffsiteCourse class.
        /// </summary>
        /// <param name="courseName">The course's name.</param>
        public OffsiteCourse(string courseName)
            : this(courseName, null, new List<string>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the OffsiteCourse class.
        /// </summary>
        /// <param name="courseName">The course's name.</param>
        /// <param name="teacherName">The course's teacher's name.</param>
        public OffsiteCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the OffsiteCourse class.
        /// </summary>
        /// <param name="courseName">The course's name.</param>
        /// <param name="teacherName">The course's teacher's name.</param>
        /// <param name="students">The list of student's names.</param>
        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
            this.Town = DEFAULT_TOWN_NAME;
        }

        /// <summary>
        /// Gets or sets the town.
        /// </summary>
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

        /// <summary>
        /// An override to the ToString() method.
        /// </summary>
        /// <returns>A comprehensible string of an OffsiteCourse instance.</returns>
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
