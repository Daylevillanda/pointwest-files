using Microsoft.AspNetCore.Mvc;

namespace _04_QueryParameters.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Demo1(string id)
        {
            int id2 = int.Parse(HttpContext.Request.Query["id2"].ToString());
            string id3 = HttpContext.Request.Query["id3"].ToString();
            
            ViewBag.id = id;
            ViewBag.id2 = id2;
            ViewBag.id3 = id3;
            
            return View("Result");
        }

    }
}