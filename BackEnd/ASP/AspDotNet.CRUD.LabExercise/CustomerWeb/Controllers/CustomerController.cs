using CustomerData.Models;
using CustomerData.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CustomerWeb.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            var customerList = this._customerRepository.FindAll();
            return View(customerList);
        }
        public IActionResult Details(Guid id)
        {
            var customer = this._customerRepository.FindByPrimaryKey(id);
            ViewData["customer"] = customer;
            return View();
        }
        public IActionResult Delete(Guid id)
        {
            this._customerRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult New()
        {
            ViewData["Action"] = "New";
            return View("Form", new Customer());
        }
        public IActionResult Edit(Guid id)
        {
            ViewData["Action"] = "Edit";
            var customer = this._customerRepository.FindByPrimaryKey(id);
            return View("Form", customer);
        }
        public IActionResult Save(string action, Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (action.ToLower().Equals("new"))
                {
                    _customerRepository.Insert(customer);
                }
                else if (action.ToLower().Equals("edit"))
                {
                    _customerRepository.Update(customer);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", customer);
            }
        }
    }
}
