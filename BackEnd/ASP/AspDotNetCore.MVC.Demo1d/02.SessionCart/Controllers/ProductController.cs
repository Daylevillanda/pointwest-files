using _02.SessionCart.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02.SessionCart.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService productService;

        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        // ViewBag used to transfer temporary data (which is not included in the model) 
        // from the controller to the view.
        public ActionResult Index()
        {
            ProductService productService = new ProductService();
            ViewBag.products = productService.FindAll();
            return View();
        }
    }
}