using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel()
            {
                Employees = _context.Employee.ToList(),
                Positions = _context.Position.ToList(),
                Units = _context.Unit.Select(x => x.DepartmentName.Distinct())
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
