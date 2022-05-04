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
    public interface ISkillRepository : IBaseRepository<Skill>
    {
        public IEnumerable<EmployeeSkillDTO> GetSkills();
    }

    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(WorkScheduleDbContext context) : base(context)
        {

        }

        public IEnumerable<EmployeeSkillDTO> GetSkills()
        {
            var skills = from s in Context.Skills
                                join e in Context.EmployeeSkills on s.SkillId equals e.SkillId into EmployeeSkill
                                from w in EmployeeSkill.DefaultIfEmpty()
                                select new EmployeeSkillDTO
                                {
                                    EmployeeId = w.EmployeeId == null ? 0 : w.EmployeeId,
                                    SkillId = s.SkillId == null ? 0 : s.SkillId,
                                    Description = s.Description
                                };
            return skills;
        }
    }
}
