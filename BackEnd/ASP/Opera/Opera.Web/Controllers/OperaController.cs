using Microsoft.AspNetCore.Mvc;
using Operas.Data.Repositories;
using System.Linq;

namespace Operas.Web.Controllers
{
    public class OperaController : Controller
    {
        private IOperaRepository _operaRepository;
        public OperaController(IOperaRepository operaRepository)
        {
            this._operaRepository = operaRepository;
        }
        public IActionResult Index()
        {
            var operaList = this._operaRepository.FindAll();
            return View(operaList);
        }
    }
}
