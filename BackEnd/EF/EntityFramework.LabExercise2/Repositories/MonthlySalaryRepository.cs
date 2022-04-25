﻿using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    public class MonthlySalaryRepository : GenericRepository<MonthlySalary>, IRepository<MonthlySalary>
    {
        public MonthlySalaryRepository(RecruitmentContext context) : base(context)
        {
        }
        public IEnumerable<MonthlySalary> FindAll(string employeeCode)
        {
            return this.Context.MonthlySalaries.Where(x => x.CEmployeeCode.Equals(employeeCode)).ToList();
        }
    }
}
