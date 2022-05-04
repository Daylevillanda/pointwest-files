using WebApiDemo.Data;
using WebApiDemo.Exceptions;
using WebApiDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo.Repositories
{
    public interface IProductOrderRepository : IBaseRepository<ProductOrder>
    {
    }

    public class ProductOrderRepository : GenericRepository<ProductOrder>, IProductOrderRepository
    {
        public ProductOrderRepository(OnlineShopContext context) : base(context)
        {
        }
    }
}
