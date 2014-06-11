namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MAX_STUDENTS_COUNT = 29;
        private List<Student> students;
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.Students = new List<Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public List<Student> Students
        {
            get
            {
                return this.students;
            }

            private set
            {
                this.students = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.Students.Count > MAX_STUDENTS_COUNT)
            {
                string message = string.Format("A class can have no more than {0} students.", MAX_STUDENTS_COUNT);
                throw new InvalidOperationException(message);
            }

            this.Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (!this.Students.Remove(student))
            {
                throw new ArgumentException("Student not present in this class.");
            }
        }
    }
}
