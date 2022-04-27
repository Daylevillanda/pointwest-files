using AspDotNewCoreMVC.Demo1b.Models;
using System.Collections.Generic;

namespace AspDotNewCoreMVC.Demo1b.Services
{
    public class EmployeeService
    {
        private List<Employee> employees;
        public EmployeeService()
        {
            this.employees = new List<Employee>();
            employees.Add(new Employee()
            {
                Id = 1,
                FirstName = "EmpFN1",
                LastName = "EmpLN1",
                Salary = 1000M,
                Position = "Pos1"
            });
            employees.Add(new Employee()
            {
                Id = 2,
                FirstName = "EmpFN2",
                LastName = "EmpLN2",
                Salary = 2000M,
                Position = "Pos2"
            });
            employees.Add(new Employee()
            {
                Id = 3,
                FirstName = "EmpFN3",
                LastName = "EmpLN3",
                Salary = 3000M,
                Position = "Pos3"
            });
            employees.Add(new Employee()
            {
                Id = 4,
                FirstName = "EmpFN4",
                LastName = "EmpLN4",
                Salary = 4000M,
                Position = "Pos4"
            });
            employees.Add(new Employee()
            {
                Id = 5,
                FirstName = "EmpFN5",
                LastName = "EmpLN5",
                Salary = 5000M,
                Position = "Pos5"
            });
        }
        public List<Employee> GetAll()
        {
            return employees;
        }
    }
}
