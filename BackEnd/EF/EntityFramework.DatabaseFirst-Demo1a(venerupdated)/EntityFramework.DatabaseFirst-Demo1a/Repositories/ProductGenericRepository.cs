using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DatabaseFirst_Demo1a.Data;
using EntityFramework.DatabaseFirst_Demo1a.Models;

namespace EntityFramework.DatabaseFirst_Demo1a.Repositories
{
    public interface IProductRepository: IRepository<Product>
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
