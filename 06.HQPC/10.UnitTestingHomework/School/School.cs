namespace School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private const int ID_NUMBER_MINIMAL_VALUE = 10000;
        private const int ID_NUMBER_MAXIMAL_VALUE = 99999;
        private List<Student> students;
        private List<Course> courses;
        private int idCounter = ID_NUMBER_MINIMAL_VALUE;

        public School()
        {
            this.Courses = new List<Course>();
            this.Students = new List<Student>();
        }

        public List<Course> Courses
        {
            get
            {
                return this.courses;
            }

            private set
            {
                this.courses = value;
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

        public int IdCounter
        {
            private get
            {
                return this.idCounter;
            }

            private set
            {
                if (value < ID_NUMBER_MINIMAL_VALUE || ID_NUMBER_MAXIMAL_VALUE > value)
                {
                    string message = string.Format("ID must be a value between {0} and {1}.",
                                                    ID_NUMBER_MINIMAL_VALUE,
                                                    ID_NUMBER_MAXIMAL_VALUE);
                    throw new ArgumentOutOfRangeException(message);
                }

                this.idCounter = value;
            }
        }

        public void AddStudent(string name)
        {
            var newStudent = new Student(name, IdCounter);
            this.Students.Add(newStudent);
            IdCounter++;
        }
    }
}
