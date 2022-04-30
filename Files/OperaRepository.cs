using AspDotNetCore.EF.Demo1c.Context;
using AspDotNetCore.EF.Demo1c.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetCore.EF.Demo1c.Repositories
{
    public interface IOperaRepository : IBaseRepository<Opera>
    {
    }

    public class OperaRepository : GenericRepository<Opera>, IOperaRepository
    {
        public OperaRepository(OperaDBContext context) : base(context)
        {
        }
    }
}
