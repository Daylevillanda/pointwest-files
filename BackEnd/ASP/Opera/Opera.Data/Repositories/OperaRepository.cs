using Operas.Data.Context;
using Operas.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operas.Data.Repositories
{
    public interface IOperaRepository : IBaseRepository<Opera>
    {
    }

    public class OperaRepository : GenericRepository<Opera>, IOperaRepository
    {
        public OperaRepository(OperaDbContext context) : base(context)
        {
        }
    }
}
