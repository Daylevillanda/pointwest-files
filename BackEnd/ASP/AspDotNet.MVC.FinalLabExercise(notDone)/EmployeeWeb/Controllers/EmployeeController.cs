using EmployeeData.Models;
using EmployeeData.Repositories;
using Microsoft.AspNetCore.Mvc;
using EmployeeWeb.Services;
using EmployeeData.DataTransferObjects;
using System.Collections.Generic;

namespace EmployeeWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeService employeeService)
        {
            this.employeeRepository = employeeRepository;
            this.employeeService = employeeService;
        }        
        
        public IActionResult Index(int page = 1)
        {
            return View(employeeService.GetEmployeePage(page));
        }

        public IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            var employee = this.employeeRepository.FindByPrimaryKey(id);
            var employeeSkill = this.employeeRepository.GetSkills(id);
            ViewBag.Skills = employeeSkill;
            return View("Form", employee);
        }

        public IActionResult Delete(int id, int page)
        {
            var employee = this.employeeRepository.FindByPrimaryKey(id);
            employee.Active = false;
            employeeRepository.Update(employee);
            return RedirectToAction("Index", new { page = page });
        }
        public IActionResult Save(string action, Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (action.ToLower().Equals("new"))
                {
                    employeeRepository.Insert(employee);
                }
                else if (action.ToLower().Equals("edit"))
                {
                    employeeRepository.Update(employee);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", employee);
            }
        }

    }

}
