namespace Company.Seeder
{
    using Company.Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class EmployeeGenerator : Generator<Employee>
    {
        private const int MIN_NAME_LENGTH = 5;
        private const int MAX_NAME_LENGTH = 20;

        private const int MIN_SALARY = 50000;
        private const int MAX_SALARY = 200000;

        private ICollection<Department> departments;

        /// <summary>
        /// Counstructor for the EmployeeGenerator class
        /// </summary>
        /// <param name="departments">Collection of departments extracted from the database</param>
        public EmployeeGenerator(ICollection<Department> departments)
            : base()
        {
            this.departments = departments;
        }

        protected override Employee GetNewItem()
        {
            int deptCount = this.departments.Count;
            var employee = new Employee();
            employee.FirstName = this.generator.GetString(MIN_NAME_LENGTH, MAX_NAME_LENGTH);
            employee.LastName = this.generator.GetString(MIN_NAME_LENGTH, MAX_NAME_LENGTH);

            employee.YearSalary = this.generator.GetInt(MIN_SALARY, MAX_SALARY);

            // Up to this point departments are already stored in the databse and have unique id
            int deptId = this.generator.GetInt(1, deptCount);
            employee.Department = this.departments.First(dept => dept.Id == deptId);

            // Managerial relations are generated separately
            return employee;
        }
    }
}
