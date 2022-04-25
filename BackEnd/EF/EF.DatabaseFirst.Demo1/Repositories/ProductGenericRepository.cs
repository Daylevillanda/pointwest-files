using EF.DatabaseFirst.Demo1.Data;
using EF.DatabaseFirst.Demo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DatabaseFirst.Demo1.Repositories
{
    public class ProductGenericRepository: GenericRepository<Product>, IRepository<Product>
    {
        public ProductGenericRepository(OnlineShopContext context): base(context)
        {
        }
    }
}
