using EmployeeData.Models;
using EmployeeData.Repositories;
using Microsoft.AspNetCore.Mvc;
using EmployeeWeb.Services;
using EmployeeData.DataTransferObjects;
using System.Collections.Generic;
using EmployeeData.Data;

namespace EmployeeWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmployeeService employeeService;

        public EmployeeController(IUnitOfWork unitOfWork, IEmployeeService employeeService)
        {
            this.unitOfWork = unitOfWork;
            this.employeeService = employeeService;
        }        
        
        public IActionResult Index(int page = 1)
        {
            return View(employeeService.GetEmployeePage(page));
        }
        public IActionResult New()
        {
            ViewData["Action"] = "New";
            return View("Form", new Employee());
        }

        public IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            var employee = this.unitOfWork.EmployeeRepository.FindByPrimaryKey(id);
            ViewBag.ExistingSkills = this.unitOfWork.SkillRepository.GetSkills();
            ViewBag.Skills = this.unitOfWork.EmployeeRepository.GetSkills(id);
            return View("Form", employee);
        }

        public IActionResult AddSkill(int employeeId, int skillId)
        {
            var newSkill = new EmployeeSkill
            {
                EmployeeId = employeeId,
                SkillId = skillId
            };
            this.unitOfWork.EmployeeSkillRepository.Insert(newSkill);
            this.unitOfWork.CommitAsync();
            return RedirectToAction("Edit", new { id = employeeId });
        }

        public IActionResult Delete(int id, int page)
        {
            var employee = this.unitOfWork.EmployeeRepository.FindByPrimaryKey(id);
            employee.Active = false;
            unitOfWork.EmployeeRepository.Update(employee);
            unitOfWork.CommitAsync();
            return RedirectToAction("Index", new { page = page });
        }
        public IActionResult Save(string action, Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (action.ToLower().Equals("new"))
                {
                    employee.Active = true;
                    unitOfWork.EmployeeRepository.Insert(employee);
                }
                else if (action.ToLower().Equals("edit"))
                {
                    unitOfWork.EmployeeRepository.Update(employee);
                }
                unitOfWork.CommitAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Action"] = action;
                return View("Form", employee);
            }
        }

    }

}
