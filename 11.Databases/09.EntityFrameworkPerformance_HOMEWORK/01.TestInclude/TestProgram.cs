namespace _01.TestInclude
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using TelerikAcademy.Models;

    class TestProgram
    {
        static void Main(string[] args)
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();
            var employees = GetEmployees(context);
            var sw = new Stopwatch();
            sw.Start();
            PrintInfo(employees); // Executes 343 queries
            sw.Stop();
            string withoutInclude = sw.Elapsed.ToString();

            var employeesWithInclude = GetEmployeesWithInclude(context);
            sw.Restart();
            PrintInfo(employeesWithInclude); // Executes 38 queries
            sw.Stop();
            string withInlcude = sw.Elapsed.ToString();

            Console.WriteLine("Without Include(): {0}", withoutInclude);
            Console.WriteLine("Executes 343 queries.");
            Console.WriteLine("With Include(): {0}", withInlcude);
            Console.WriteLine("Executes 1 query.");
        }

        private static IEnumerable<Employee> GetEmployees(TelerikAcademyEntities context)
        {
            var employees = context.Employees;
            return employees;
        }

        private static IEnumerable<Employee> GetEmployeesWithInclude(TelerikAcademyEntities context)
        {
            var employees = context.Employees.Include("Department").Include("Address").Include("Address.Town");
            return employees;
        }

        private static void PrintInfo(IEnumerable<Employee> employees)
        {
            var sbuilder = new StringBuilder();
            foreach (var employee in employees)
            {
                var name = employee.FirstName + " " + employee.MiddleName + " " + employee.LastName;
                var dept = employee.Department.Name;
                var town = employee.Address.Town.Name;

                string format = "Name: {0}; Dept: {1}; Town: {2}";
                string info = string.Format(format, name, dept, town);

                sbuilder.AppendLine(info);
            }

            var buletin = sbuilder.ToString();
            Console.WriteLine(buletin);
            Console.WriteLine();
        }
    }
}
