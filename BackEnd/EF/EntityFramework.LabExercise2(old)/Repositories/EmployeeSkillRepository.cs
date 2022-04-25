using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    internal class EmployeeSkillRepository : GenericRepository<EmployeeSkill>, IRepository<EmployeeSkill>
    {
        public EmployeeSkillRepository(RecruitmentContext context) : base(context)
        {
        }
        public IEnumerable<EmployeeSkill> FindAll(string employeeCode)
        {
            //return this.Context.MonthlySalaries.Where(x => x.CEmployeeCode.Equals(employeeCode)).ToList();
        }
    }
}


//private string connectionString;
//public RecruitmentContext(string connectionString)
//{
//    this.connectionString = connectionString;
//}