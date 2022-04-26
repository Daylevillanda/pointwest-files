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
    public class ProductRepository
    {
        public ProductRepository(OnlineShopContext context)
        {
            this.Context = context;
        }

        public OnlineShopContext Context { get; set; }

        public Product Save(Product product)
        {
            Context.Products.Add(product);
            Context.SaveChanges();

            return product;
        }

        public IEnumerable<Product> FindAll()
        {
            var products = this.Context.Products.Select(p => p).ToList();
            return products;
        }

        public Product FindByPrimaryKey(int id)
        {
            var product = this.Context.Products.Where(p => p.Id == id).FirstOrDefault();
            if (product is object)
            {
                return product;
            }
            throw new Exception($"Product does not exist {id}");
        }

        public Product Update(Product product)
        {
            this.FindByPrimaryKey(product.Id);

            this.Context.Products.Attach(product);
            this.Context.Entry(product).State = EntityState.Modified;
            this.Context.SaveChanges();

            return product;
        }

        public Product Delete(int id)
        {
            var existingProduct = this.FindByPrimaryKey(id);

            this.Context.Products.Remove(existingProduct);
            this.Context.SaveChanges();

            return existingProduct;
        }
    }
}
