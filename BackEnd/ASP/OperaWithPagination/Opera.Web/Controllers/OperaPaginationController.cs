using Microsoft.AspNetCore.Mvc;
using Operas.Data.Models;
using Operas.Data.Repositories;
using Operas.Web.Services;
using System;
using System.Linq;

namespace Operas.Web.Controllers
{
    public class OperaPaginationController : Controller
    {
        private readonly IOperaService operaService;

        public OperaPaginationController(IOperaService operaService)
        {
            this.operaService = operaService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(operaService.GetOperaPage(1));
        }

        [HttpPost]
        public IActionResult Index(int currentPageIndex)
        {
            return View(operaService.GetOperaPage(currentPageIndex));
        }
        
    }
}
