using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UIUCSalary.Models
{
    public partial class Position
    {
        public Position()
        {
            Job = new HashSet<Job>();
        }

        [Key]
        [Column("Position_ID")]
        public int PositionId { get; set; }
        [Required]
        [Column("Position_Name")]
        public string PositionName { get; set; }

        [InverseProperty("Position")]
        public virtual ICollection<Job> Job { get; set; }
    }
}
