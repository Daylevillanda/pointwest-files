using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Exceptions;
using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
    }

    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(OnlineShopContext context) : base(context)
        {
        }
    }
}
