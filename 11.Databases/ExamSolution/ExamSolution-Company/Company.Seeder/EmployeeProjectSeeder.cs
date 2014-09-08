namespace Company.Seeder
{
    using Company.Data;
    using System.Data.Entity;
    using System.Linq;
    using Company.Models;
    using System.Collections.Generic;
    using System;

    public class EmployeeProjectSeeder
    {
        private readonly DateTime START_DATE_START = DateTime.Parse("1.1.1995");
        private readonly DateTime END_DATE_START = DateTime.Parse("31.12.2000");
        private readonly DateTime START_DATE_END = DateTime.Parse("1.1.2001");
        private readonly DateTime END_DATE_END = DateTime.Parse("31.12.2020");
        private DbSet<Employees_Projects> employees_Projects;
        private DbSet<Employee> employees;
        private DbSet<Project> projects;
        private RandomDataGenerator generator;
        private CompanyModel context;

        public EmployeeProjectSeeder(DbSet<Employees_Projects> employees_Projects,
            DbSet<Employee> employees,
            DbSet<Project> projects,
            RandomDataGenerator generator,
            CompanyModel context)
        {
            this.employees_Projects = employees_Projects;
            this.employees = employees;
            this.projects = projects;
            this.generator = generator;
            this.context = context;
        }

        public void SeedEmployeesProjects()
        {
            int employeesCount = this.employees.Count();
            var projs = this.projects.ToList();
            foreach (var project in projs)
            {
                //context.Projects.Attach(project);
                int employeesCountForProject = this.GetEmployeesCountForProject();
                for (int i = 0; i < employeesCountForProject; i++)
                {
                    var alreadyGiven = new List<int>();
                    var employeeProject = new Employees_Projects();
                    //context.Employees_Projects.Attach(employeeProject);
                    employeeProject.Project = project;

                    int employeeId = this.generator.GetInt(1, employeesCount);
                    while (alreadyGiven.Contains(employeeId))
                    {
                        employeeId = this.generator.GetInt(1, employeesCount);
                    }

                    alreadyGiven.Add(employeeId);

                    var employee = this.employees.First(empl => empl.Id == employeeId);
                    //context.Employees.Attach(employee);
                    employeeProject.Employee = employee;

                    employeeProject.StartDate = this.generator.GetRandomDate(START_DATE_START, END_DATE_START);

                    employeeProject.EndDate = this.generator.GetRandomDate(START_DATE_END, END_DATE_START);

                    context.Employees_Projects.Add(employeeProject);
                }

                Console.Write('.');
                context.SaveChanges();
            }
        }

        private int GetEmployeesCountForProject()
        {
            int count;
            var isAroundAverage = this.generator.GetChance(60);
            if (isAroundAverage)
            {
                count = this.generator.GetInt(2, 7);
            }
            else
            {
                var areMany = this.generator.GetChance(20);
                if (areMany)
                {
                    count = this.generator.GetInt(15, 20);
                }
                else
                {
                    count = this.generator.GetInt(8, 14);
                }
            }

            return count;
        }
    }
}
