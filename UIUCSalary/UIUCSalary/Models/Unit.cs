using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UIUCSalary.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Job = new HashSet<Job>();
        }

        [Key]
        [Column("Unit_ID")]
        public int UnitId { get; set; }
        [Required]
        [Column("Department_Name")]
        public string DepartmentName { get; set; }
        [Required]
        [Column("College_Name")]
        public string CollegeName { get; set; }
        [Required]
        [Column("Campus_Name")]
        public string CampusName { get; set; }

        [InverseProperty("Unit")]
        public virtual ICollection<Job> Job { get; set; }
    }
}
