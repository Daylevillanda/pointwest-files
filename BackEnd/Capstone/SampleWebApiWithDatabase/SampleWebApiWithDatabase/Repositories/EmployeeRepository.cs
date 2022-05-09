using SampleWebApiWithDatabase.Data;
using SampleWebApiWithDatabase.Models;
using System.Threading.Tasks;

namespace SampleWebApiWithDatabase.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
    }
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(db context) : base(context)
        {
        }

    }
}
