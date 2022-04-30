using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _02.SessionCart.Models;
using _02.SessionCart.Extensions;
using _02.SessionCart.Services;

namespace c
{
    public class CartController : Controller
    {
        private readonly ProductService productService;
        
        public CartController(ProductService productService)
        {
            this.productService = productService;
        }

        public ActionResult Index()
        {
            if (HttpContext.Session.Get("cart") == null)
            {
                List<Item> cart = new List<Item>();

                HttpContext.Session.SetObject("cart", cart);
            }
            
            return View();
        }

        public ActionResult Add(string id)
        {
            if (HttpContext.Session.GetObject<List<Item>>("cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = productService.Find(id), Quantity = 1 });
                HttpContext.Session.SetObject("cart", cart);
            }
            else
            {
                List<Item> cart = HttpContext.Session.GetObject<List<Item>>("cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = productService.Find(id), Quantity = 1 });
                }
                HttpContext.Session.SetObject("cart", cart);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(string id)
        {
            List<Item> cart = HttpContext.Session.GetObject<List<Item>>("cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<Item> cart = HttpContext.Session.GetObject<List<Item>>("cart");
            for (int i = 0; i < cart.Count; i++) 
                if (cart[i].Product.Id.Equals(id))
                    return i;
            return -1;
        }
    }
}