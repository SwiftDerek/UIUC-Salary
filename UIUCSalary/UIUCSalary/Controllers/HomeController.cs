using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UIUCSalary.Models;
using UIUCSalary.Models.ViewModels;

namespace UIUCSalary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UIUCSalaryContext _context;

        public HomeController(ILogger<HomeController> logger, UIUCSalaryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            IndexViewModel indexViewModel = new IndexViewModel()
            {
                Employees = await _context.Employee.ToListAsync()
            };

            if (!String.IsNullOrEmpty(searchString))
            {
                indexViewModel.Employees = indexViewModel.Employees.Where(s => s.EmployeeName.Contains(searchString.ToLower()));
            }
            else
            {
                indexViewModel.Employees = null;
            }
            return View(indexViewModel);
        }

        public async Task<IActionResult> Salary(int EmployeeId)
        {
            var totalSalary = _context.Job.Where(s => s.EmployeeId == EmployeeId).Select(s => s.Salary).Sum();

            var employeeGroupedYears = _context.Job.Where(s => s.EmployeeId == EmployeeId).GroupBy(c => c.Year);


            IndexViewModel indexViewModel = new IndexViewModel()
            {
                Employees = await _context.Employee.ToListAsync()
            };

            return View(indexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
