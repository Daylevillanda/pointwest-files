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
    public interface IProductRepository : IBaseRepository<Product>
    {
        IEnumerable<Product> FindProductsByName(string name);

        IEnumerable<Product> FindProductsByPrice(decimal startPrice, decimal endPrice);
    }

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(OnlineShopContext context) : base(context)
        {
        }

        public IEnumerable<Product> FindProductsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new EntityDataException("Name cannot be null or empty.");
            }

            var products = this.Context.Products.Where(p => p.Name.Contains(name)).ToList();
            return products;
        }

        public IEnumerable<Product> FindProductsByPrice(decimal startPrice, decimal endPrice)
        {
            var products = this.Context.Products.Where(p => p.Price >= startPrice && p.Price <= endPrice).ToList();
            return products;
        }
    }
}
