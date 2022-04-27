using AspDotNewCoreMVC.Demo1b.Configuration;
using AspDotNewCoreMVC.Demo1b.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNewCoreMVC.Demo1b.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmailSettings _emailSettings;
        private readonly EmployeeService _employeeService;
        public EmployeeController(EmailSettings emailSettings, EmployeeService employeeService)
        {
            this._emailSettings = emailSettings;
            this._employeeService = employeeService;
        }
        public IActionResult Index()
        {
            ViewData["EmailSettings"] = this._emailSettings;
            ViewData["Employees"] = this._employeeService.GetAll();
            return View();
        }
    }
}
