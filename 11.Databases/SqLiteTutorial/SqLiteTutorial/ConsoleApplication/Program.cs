using SQLiteTutorial.Data;
using System;
using System.Linq;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentsDdContext dbcont = new StudentsDdContext();

            Console.WriteLine(dbcont.Courses.First().Name);

            //Course course = new Course();
            //course.Name = "Databases";

            //dbcont.Courses.Add(course);

            //Console.WriteLine(dbcont.SaveChanges());

            //var courses = dbcont.Courses.Where(c => c.ID > 0);

            //foreach (var item in courses)
            //{
            //    Console.WriteLine(item.ID + " " + item.Name);
            //}
        }
    }
}
