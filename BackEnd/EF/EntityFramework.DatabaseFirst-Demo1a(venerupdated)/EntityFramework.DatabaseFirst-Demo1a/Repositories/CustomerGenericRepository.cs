using EntityFramework.DatabaseFirst_Demo1a.Data;
using EntityFramework.DatabaseFirst_Demo1a.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.DatabaseFirst_Demo1a.Repositories
{
    internal class CustomerGenericRepository : GenericRepository<Customer>, IRepository<Customer>
    {
        public CustomerGenericRepository(OnlineShopContext context) : base(context)
        {
        }
    }
}
