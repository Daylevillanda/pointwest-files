using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Repository
{
    public class ProductRepository : GenericRepository<Product>, IBaseRepository<Product>
    {
        public ProductRepository(OnlineShopContext context) : base(context)
        {
        }
    }
}
