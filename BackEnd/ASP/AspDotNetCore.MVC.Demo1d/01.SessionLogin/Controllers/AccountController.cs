using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _01.SessionLogin.Filters;

namespace _01_Session_Login.Controllers
{
    
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if(HttpContext.Session.GetString("username") != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username.Equals("acc1") && password.Equals("123"))
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }

    }
}