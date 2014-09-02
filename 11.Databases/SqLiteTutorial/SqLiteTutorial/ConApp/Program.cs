using SQLiteTutorial.Data;
using SQLiteTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentsDdContext dbcont = new StudentsDdContext();

            Course course = new Course();
            course.Name = "Databases";

            dbcont.Courses.Add(course);

            Console.WriteLine(dbcont.SaveChanges());

            var courses = dbcont.Courses.Where(c => c.ID > 0);

            foreach (var item in courses)
            {
                Console.WriteLine(item.ID + " " + item.Name);
            }
        }
    }
}
