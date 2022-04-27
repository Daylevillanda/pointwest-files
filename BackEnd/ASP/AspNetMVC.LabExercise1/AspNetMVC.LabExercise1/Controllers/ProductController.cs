using AspNetMVC.LabExercise1.Service;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVC.LabExercise1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            this._productService = productService;
        }
        public IActionResult List()
        {
            ViewData["Products"] = this._productService.GetCatalog();
            ViewData["GrandTotal"] = this._productService.GetGrandTotal();
            return View();
        }
    }
}
