using SampleWebApiWithDatabase.Repositories;
using System;
using System.Threading.Tasks;

namespace SampleWebApiWithDatabase.Data
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        public IEmployeeRepository EmployeeRepository { get; }
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private db context;

        public IEmployeeRepository EmployeeRepository { get; private set; }

        public UnitOfWork(db context)
        {
            this.context = context;
            this.EmployeeRepository = new EmployeeRepository(context);
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
