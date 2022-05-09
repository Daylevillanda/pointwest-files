using System;
using System.Collections.Generic;

#nullable disable

namespace SampleWebApiWithDatabase.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeSkills = new HashSet<EmployeeSkill>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomePhone { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
