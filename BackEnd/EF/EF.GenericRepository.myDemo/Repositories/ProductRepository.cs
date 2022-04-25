using EF.GenericRepository.myDemo.Data;
using EF.GenericRepository.myDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.GenericRepository.myDemo.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        public IEnumerable<Product> FindByPrice(decimal minimumPrice, decimal maximumPrice);
    }


    public class ProductGenericRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductGenericRepository(OnlineShopContext context) : base(context)
        {
        }

        public IEnumerable<Product> FindByPrice(decimal minimumPrice, decimal maximumPrice)
        {
            var filteredProducts = this.Context.Products.Where(p => p.Price >= minimumPrice && p.Price <= maximumPrice).ToList();
            return filteredProducts;
        }
    }
}
