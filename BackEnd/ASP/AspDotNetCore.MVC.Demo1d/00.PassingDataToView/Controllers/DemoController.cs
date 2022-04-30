using _00.PassingDataToView.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace _00.PassingDataToView.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            ViewBag.age = 20;
            ViewBag.fullName = "John Doe";
            ViewBag.status = true;
            ViewBag.price = 4.5;
            ViewBag.birthday = DateTime.Now;

            Product product = new Product()
            {
                Id = "p01",
                Name = "Name 1",
                Photo = "thumb1.jpg",
                Price = 5.5,
                Quantity = 4
            };
            ViewBag.product = product;

            List<Product> products = new List<Product>() {
                new Product () {
                    Id = "p01",
                    Name = "Name 1",
                    Photo = "thumb1.jpg",
                    Price = 5.5,
                    Quantity = 4
                },
                new Product () {
                    Id = "p02",
                    Name = "Name 2",
                    Photo = "thumb2.jpg",
                    Price = 7,
                    Quantity = 3
                },
                new Product () {
                    Id = "p03",
                    Name = "Name 3",
                    Photo = "thumb3.jpg",
                    Price = 8,
                    Quantity = 6
                }
            };
            ViewBag.products = products;

            return View();
        }
    }
}
