namespace Company.Seeder
{
    using System.Data.Entity;
    using System.Linq;
    using Company.Models;
    using Company.Data;
    using System;

    public class ManagerialSeeder
    {
        private const int MANAGERIAL_PERCENTAGE = 95;
        private const int FLUSH_TRESHOLD = 100;
        private DbSet<Employee> employees;
        protected RandomDataGenerator generator;
        private CompanyModel context;

        public ManagerialSeeder(DbSet<Employee> employees, RandomDataGenerator generator, CompanyModel context)
        {
            this.employees = employees;
            this.generator = generator;
            this.context = context;
        }

        public void SeedManagers()
        {
            int employeesCount = this.employees.Count();
            int counter = 0;

            var emps = context.Employees.ToList();

            // TODO: Implement cycle restriction
            foreach (var employee in emps)
            {
                this.context.Employees.Attach(employee);
                bool hasManager = this.generator.GetChance(MANAGERIAL_PERCENTAGE);
                if (hasManager)
                {
                    int managerId = this.generator.GetInt(1, employeesCount);
                    employee.ManagerId = managerId;
                }

                counter++;

                if (counter == FLUSH_TRESHOLD)
                {
                    this.context.SaveChanges();
                    Console.Write('.');
                    counter = 0;
                }
            }

            context.SaveChanges();
        }
    }
}
