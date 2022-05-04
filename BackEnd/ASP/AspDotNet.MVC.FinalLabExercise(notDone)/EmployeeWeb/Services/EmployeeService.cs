using System;
using System.Linq;
using EmployeeData.Data;
using EmployeeData.Models;
using EmployeeData.Repositories;
using EmployeeWeb.Models;


namespace EmployeeWeb.Services
{
    public interface IEmployeeService
    {
        public PagedResult<Employee> GetEmployeePage(int currentPage);
    }

    public class EmployeeService : GenericService, IEmployeeService
    {

        public EmployeeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { 
        }
        public PagedResult<Employee> GetEmployeePage(int currentPage)
        {
            return GetPaged<Employee>(unitOfWork.EmployeeRepository.Context.Employees.Where(e=>e.Active.Equals(true)), currentPage, 10);
        }
    }
}
