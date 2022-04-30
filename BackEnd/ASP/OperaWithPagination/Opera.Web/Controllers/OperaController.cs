using Microsoft.AspNetCore.Mvc;
using Operas.Data.Models;
using Operas.Data.Repositories;
using System;
using System.Linq;

namespace Operas.Web.Controllers
{
    public class OperaController : Controller
    {
        private IOperaRepository operaRepository;

        public OperaController(IOperaRepository operaRepository)
        {
            this.operaRepository = operaRepository;
        }
        public IActionResult Index()
        {
            var operaList = this.operaRepository.FindAll().ToList();
            return View(operaList);
        }

        public IActionResult Details(Guid id)
        {
            var opera = this.operaRepository.FindByPrimaryKey(id);
            ViewData["Opera"] = opera;
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            var opera = this.operaRepository.Delete(id);
            
            return RedirectToAction("Index");
        }

        public IActionResult New()
        {
            ViewData["Action"] = "New";
            return View("Form", new OperaEntity());
        }

        public IActionResult Edit(Guid id)
        {
            ViewData["Action"] = "Edit";
            var opera = this.operaRepository.FindByPrimaryKey(id);
            return View("Form", opera);
        }

        public IActionResult Save(string action, OperaEntity opera)
        {
            if (ModelState.IsValid)
            {
                if(action.ToLower().Equals("new"))
                {
                    operaRepository.Insert(opera);
                } 
                else if (action.ToLower().Equals("edit"))
                {
                    operaRepository.Update(opera);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", opera);
            }
        }
    }
}
