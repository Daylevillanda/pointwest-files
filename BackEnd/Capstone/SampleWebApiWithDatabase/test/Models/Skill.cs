using System;
using System.Collections.Generic;

#nullable disable

namespace test.Models
{
    public partial class Skill
    {
        public Skill()
        {
            EmployeeSkills = new HashSet<EmployeeSkill>();
        }

        public int SkillId { get; set; }
        public string Description { get; set; }
        public bool RequiresTicket { get; set; }

        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
