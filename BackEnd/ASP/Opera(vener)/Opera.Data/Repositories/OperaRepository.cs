using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operas.Data.Context;
using Operas.Data.Models;

namespace Operas.Data.Repositories
{
    public interface IOperaRepository : IBaseRepository<OperaEntity>
    {
    }

    public class OperaRepository : GenericRepository<OperaEntity>, IOperaRepository
    {
        public OperaRepository(OperaDbContext context) : base(context)
        {
        }
    }
}
