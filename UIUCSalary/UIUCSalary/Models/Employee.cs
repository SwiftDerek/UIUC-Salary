using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UIUCSalary.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Job = new HashSet<Job>();
        }

        [Key]
        [Column("Employee_ID")]
        public int EmployeeId { get; set; }
        [Required]
        [Column("Employee_Name")]
        public string EmployeeName { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<Job> Job { get; set; }
    }
}
