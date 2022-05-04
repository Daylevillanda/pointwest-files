using EmployeeData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.Data
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        public IEmployeeRepository EmployeeRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public IEmployeeSkillRepository EmployeeSkillRepository { get; }
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private WorkScheduleDbContext context;

        public IEmployeeRepository EmployeeRepository { get; private set; }
        public ISkillRepository SkillRepository { get; private set; }
        public IEmployeeSkillRepository EmployeeSkillRepository { get; private set; }

        public UnitOfWork(WorkScheduleDbContext context)
        {
            this.context = context;
            this.EmployeeRepository = new EmployeeRepository(context);
            this.SkillRepository = new SkillRepository(context);
            this.EmployeeSkillRepository = new EmployeeSkillRepository(context);
        }

        public async Task CommitAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
