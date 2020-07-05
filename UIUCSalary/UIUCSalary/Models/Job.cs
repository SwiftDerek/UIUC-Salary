using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UIUCSalary.Models
{
    public partial class Job
    {
        [Key]
        [Column("Job_ID")]
        public int JobId { get; set; }
        [Column("Employee_ID")]
        public int EmployeeId { get; set; }
        [Column("Position_ID")]
        public int PositionId { get; set; }
        [Column("Unit_ID")]
        public int UnitId { get; set; }
        public double Salary { get; set; }
        public int Year { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("Job")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(PositionId))]
        [InverseProperty("Job")]
        public virtual Position Position { get; set; }
        [ForeignKey(nameof(UnitId))]
        [InverseProperty("Job")]
        public virtual Unit Unit { get; set; }
    }
}
