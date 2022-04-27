using Microsoft.AspNetCore.Mvc;

namespace ASPDotNeMVC.Demo1.Controllers
{
    // -> /HelloWorld
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult AnotherIndex()
        {
            //return View("../HelloWorld/Index");
            return View("~/Pages/HelloWorld/Index.cshtml");
        }
    }
}
