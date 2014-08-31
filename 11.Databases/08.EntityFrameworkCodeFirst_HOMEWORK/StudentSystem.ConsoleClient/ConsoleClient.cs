namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;

    using StudentSystem.Data;

    class ConsoleClient
    {
        static void Main()
        {
            var db = new StudentSystemContext();
            
            Console.WriteLine("Students seeded in database:");
            foreach (var student in db.Students)
            {
                Console.WriteLine(student.Name);
            }

            Console.WriteLine("Courses seeded in database:");
            foreach (var course in db.Courses)
            {
                Console.WriteLine(course.Name);
            }

            Console.WriteLine("Assignments seeded in database:");
            foreach (var homework in db.Homework)
            {
                Console.WriteLine(homework.Content);
            }
        }
    }
}
