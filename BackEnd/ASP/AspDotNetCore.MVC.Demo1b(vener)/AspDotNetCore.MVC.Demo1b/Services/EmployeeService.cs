using AspDotNetCore.MVC.Demo1b.Models;
using System.Collections.Generic;

namespace AspDotNetCore.MVC.Demo1b.Services
{
    public class EmployeeService
    {
        private List<Employee> employees;

        public EmployeeService()
        {
            employees = new List<Employee>();   

            employees.Add(new Employee()
            {
                Id = 1,
                FirstName = "BongBong",
                LastName = "Sumbong",
                Salary = 15_000M,
                Position = "President"
            });

            employees.Add(new Employee()
            {
                Id = 2,
                FirstName = "Leni",
                LastName = "Mekeni",
                Salary = 25_000M,
                Position = "Vice President"
            });

            employees.Add(new Employee()
            {
                Id = 3,
                FirstName = "Ping",
                LastName = "Chef",
                Salary = 10_000M,
                Position = "VP of Marketing"
            });
        }

        public List<Employee> GetAll()
        {
            return employees;
        }

    }
}
