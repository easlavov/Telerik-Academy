namespace Company.ConsoleClient
{
    using Company.Data;
    using Company.Models;
    using Company.Seeder;
    using System;
    using System.Linq;

    class Client
    {
        private const int DEPARTMENTS_COUNT = 100;
        private const int EMPLOYEES_COUNT = 5000;
        private const int PROJECTS_COUNT = 1000;
        private const int REPORTS_COUNT = 250000;

        static void Main()
        {
            var company = new CompanyModel();
            SeedDatabase(company);
        }

        private static void SeedDatabase(CompanyModel context)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            // Depts
            Console.WriteLine("Seeding departments");
            var deptGener = new DepartmentGenerator();
            var generatedDepts = deptGener.GetGeneratedItems(DEPARTMENTS_COUNT);
            var deptSeeder = new Seeder<Department>(context.Departments, generatedDepts, context);
            deptSeeder.Seed();

            // Projects
            Console.WriteLine("Seeding projects");
            var projGener = new ProjectGenerator();
            var generatedProj = projGener.GetGeneratedItems(PROJECTS_COUNT);
            var projSeeder = new Seeder<Project>(context.Projects, generatedProj, context);
            projSeeder.Seed();

            // Employees
            Console.WriteLine("Seeding employees");
            var empGener = new EmployeeGenerator(context.Departments.ToList());
            var generatedEmps = empGener.GetGeneratedItems(EMPLOYEES_COUNT);
            var empSeeder = new Seeder<Employee>(context.Employees, generatedEmps, context);
            empSeeder.Seed();

            // Reports
            Console.WriteLine("Seeding reports");
            var repGener = new ReportGenerator(context.Employees.ToList());
            var generatedReps = repGener.GetGeneratedItems(REPORTS_COUNT);
            var repSeeder = new Seeder<Report>(context.Reports, generatedReps, context);
            repSeeder.Seed();

            // Managers
            Console.WriteLine("Attaching managers");
            var company = new CompanyModel();
            var managerSeeder = new ManagerialSeeder(context.Employees, new RandomDataGenerator(), company);
            managerSeeder.SeedManagers();

            // EmplProj
            Console.WriteLine("Attaching projects. Possible random exception");
            var companyNew = new CompanyModel();
            var emplProj = new EmployeeProjectSeeder(
                companyNew.Employees_Projects, companyNew.Employees, companyNew.Projects, new RandomDataGenerator(), companyNew);
            emplProj.SeedEmployeesProjects();

            context.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
