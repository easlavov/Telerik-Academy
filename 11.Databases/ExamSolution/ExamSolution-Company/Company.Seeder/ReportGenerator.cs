namespace Company.Seeder
{
    using Company.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReportGenerator : Generator<Report>
    {
        private readonly DateTime START_DATE = DateTime.Parse("1.1.1995");
        private readonly DateTime END_DATE = DateTime.Parse("31.12.2020");
        private ICollection<Employee> employees;
        
        public ReportGenerator(ICollection<Employee> employees)
        {
            this.employees = employees;
        }

        protected override Report GetNewItem()
        {
            var report = new Report();
            int employeeId = this.generator.GetInt(1, this.employees.Count);
            report.Employee = this.employees.First(emp => emp.Id == employeeId);
            report.ReportTime = this.generator.GetRandomDate(START_DATE, END_DATE);
            return report;
        }
    }
}
