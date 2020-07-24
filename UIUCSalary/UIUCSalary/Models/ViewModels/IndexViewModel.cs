using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIUCSalary.Models.ViewModels
{
    public class IndexViewModel
    {
        //public IEnumerable<Job> Jobs { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public IEnumerable<Position> Positions { get; set; }

        public IEnumerable<Unit> Units { get; set; }

    }
}
