using EntityFramework.DatabaseFirst_Demo1a.Data;
using EntityFramework.DatabaseFirst_Demo1a.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.DatabaseFirst_Demo1a.Repositories
{
    internal class ProductRepository
    {
        public OnlineShopContext Context { get; set; }

        public ProductRepository(OnlineShopContext context)
        {
            this.Context = context;
        }

        public IEnumerable<Product> FindAll()
        {
            return this.Context.Products.Select(p => p).ToList();
        }
       
        public Product FindById(int id)
        {
            var product = this.Context.Products.Where(p => p.Id == id).FirstOrDefault();
            if(product != null)
            {
                return product;
            }
            throw new Exception($"Model with ID {id} doesn't exist");
        }

        public Product Save(Product product)
        {
            this.Context.Products.Add(product);
            this.Context.SaveChanges();
            return product;
        }

        public Product Update(Product product)
        {
            this.FindById(product.Id);

            this.Context.Products.Attach(product);
            this.Context.Entry(product).State = EntityState.Modified;
            this.Context.SaveChanges();

            return product;
        }

        public Product Delete(int id)
        {
            var existingProduct = FindById(id);

            this.Context.Products.Remove(existingProduct);
            this.Context.SaveChanges();

            return existingProduct;
        }
    }
}
