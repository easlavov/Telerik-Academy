namespace Company.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Company.Data;
    using Company.Models;

    public partial class Employee
    {
        public Employee()
        {
            Employees1 = new HashSet<Employee>();
            Employees_Projects = new HashSet<Employees_Projects>();
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Column(TypeName = "money")]
        public decimal YearSalary { get; set; }

        public int? ManagerId { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Employee> Employees1 { get; set; }

        public virtual Employee Employee1 { get; set; }

        public virtual ICollection<Employees_Projects> Employees_Projects { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
