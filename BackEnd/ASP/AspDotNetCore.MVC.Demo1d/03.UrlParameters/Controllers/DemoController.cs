using Microsoft.AspNetCore.Mvc;

namespace _03_UrlParameters.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Demo1(string id)
        {
            ViewBag.result = id;
            return View("Result");
        }

        public ActionResult Demo2(int id, int id2)
        {
            ViewBag.result = id + id2;
            return View("Result");
        }
    }
}