namespace _02.TestToList
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using TelerikAcademy.Models;

    class TestProgram
    {
        static void Main(string[] args)
        {
            var context = new TelerikAcademyEntities();
            QueryUnoptimized(context);
            QueryOptimized(context);
        }

        private static void QueryUnoptimized(TelerikAcademyEntities context)
        {
            var sw = new Stopwatch();
            string townName = "Sofia";
            sw.Start();
            var employees = context.Employees.ToList()
                                   .Select(emp => emp.Address).ToList()
                                   .Select(addr => addr.Town).ToList()
                                   .Where(town => town.Name == townName).ToList();
            sw.Stop();
            Console.WriteLine(employees.Count);
            Console.WriteLine("Unoptimized result: {0}", sw.Elapsed);
        }

        private static void QueryOptimized(TelerikAcademyEntities context)
        {
            var sw = new Stopwatch();
            string townName = "Sofia";
            sw.Start();
            var employees = context.Employees
                                   .Select(emp => new
                                   {
                                       // All fields required per task
                                       FullName = emp.FirstName + " " + emp.MiddleName + " " + emp.LastName,
                                       Address = emp.Address.AddressText,
                                       Town = emp.Address.Town.Name
                                   })
                                   .Where(selected => selected.Town == townName)
                                   .ToList();

            sw.Stop();
            Console.WriteLine(employees.Count);
            Console.WriteLine("Optimized result: {0}", sw.Elapsed);
        }
    }
}
