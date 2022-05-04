using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeData.Models;
using EmployeeData.Data;
using EmployeeData.DataTransferObjects;

namespace EmployeeData.Repositories
{
    public interface IEmployeeSkillRepository : IBaseRepository<EmployeeSkill>
    {
    }

    public class EmployeeSkillRepository : GenericRepository<EmployeeSkill>, IEmployeeSkillRepository
    {
        public EmployeeSkillRepository(WorkScheduleDbContext context) : base(context)
        {

        }
    }
}
