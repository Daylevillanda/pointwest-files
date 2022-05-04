using System;
using TestDB.Data;
using TestDB.Models;
using System.Linq;

namespace TestDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmpContext empContext = new EmpContext();
            var some = empContext.EmployeeSkills;

            //var leftOuterJoin = from s in empContext.Skills
            //                    join e in empContext.EmployeeSkills on s.SkillId equals e.SkillId into someRange
            //                    from w in someRange.DefaultIfEmpty()
            //                    select new
            //                    {
            //                        empid = w.EmployeeId.ToString(),
            //                        skid = w.SkillId.ToString(),
            //                        skide = s.Description.ToString(),
            //                        skir = s.RequiresTicket.ToString(),
            //                    };
            var leftOuterJoin = from s in empContext.Skills
                                join e in empContext.EmployeeSkills on s.SkillId equals e.SkillId into someRange
                                from w in someRange.DefaultIfEmpty()
                                select new
                                {
                                    empid = w.EmployeeId == null ? 0 : w.EmployeeId,
                                    skid = w.SkillId == null ? 0:w.SkillId,
                                    skide = s.Description.ToString(),
                                    skir = s.RequiresTicket.ToString(),
                                };

            //foreach (var skill in some)
            //{
            //    Console.WriteLine(skill.EmployeeId);
            //    Console.WriteLine(skill.SkillId);
            //}

            foreach (var skill in leftOuterJoin)
            {
                Console.WriteLine(skill.empid);
                Console.WriteLine(skill.skid);
                Console.WriteLine(skill.skide);
                Console.WriteLine(skill.skir);
                Console.WriteLine("----------");
            }


        }
    }
}
