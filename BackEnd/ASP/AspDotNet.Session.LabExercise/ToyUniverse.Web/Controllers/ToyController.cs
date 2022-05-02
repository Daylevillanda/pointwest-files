using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToyUniverse.Data.Repositories;
using ToyUniverse.Web.Services;

namespace ToyUniverse.Web.Controllers
{
    public class ToyController : Controller
    {
        private readonly IToyService _toyService;
        public ToyController(IToyService toyService)
        {
            this._toyService = toyService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_toyService.GetOperaPage(1));
        }

        [HttpPost]
        public IActionResult Index(int currentPageIndex)
        {
            return View(_toyService.GetOperaPage(currentPageIndex));
        }
    }
}
