using AspDotNetCore.MVC.Demo1b.Configuration;
using AspDotNetCore.MVC.Demo1b.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCore.MVC.Demo1b.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmailSettings _emailSettings;
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmailSettings emailSettings, EmployeeService employeeService)
        {
            _emailSettings = emailSettings;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            // ViewBag, ViewData, TempData
            ViewData["EmailSettings"] = _emailSettings;
            ViewData["EmployeeList"] = _employeeService.GetAll();
            return View();
        }
    }
}
