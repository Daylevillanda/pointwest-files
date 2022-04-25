using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.DatabaseFirst.Demo1.Data;
using EF.DatabaseFirst.Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace EF.DatabaseFirst.Demo1.Repositories
{
    public class ProductRepository
    {
        private static ProductRepository INSTANCE;

        private OnlineShopContext context;
        public static ProductRepository Instance(OnlineShopContext context)
        {
            if (INSTANCE == null)
            {
                INSTANCE = new ProductRepository(context);
            }
            return INSTANCE;
        }

        private ProductRepository(OnlineShopContext context)
        {
            this.context = context;
        }
        public IEnumerable<Product> FindAll()
        {
            return this.context.Products.ToList();
        }
        public Product FindById(int id)
        {
            var product = this.context.Products.Find(id);
            if (product != null)
            {
                return product;
            }

            throw new Exception($"Model with ID {id} doesn't Exist");
        }
        public Product Save(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
            return product;
        }

        public Product Update(Product product) // transient
        {
            this.FindById(product.Id);

            this.context.Products.Attach(product);
            this.context.Entry(product).State = EntityState.Modified;
            this.context.SaveChanges();
            return product;
        }

        public Product Delete(int id) // transient
        {
            var existingProduct = FindById(id);
            this.context.Products.Remove(existingProduct);
            this.context.SaveChanges();
            return existingProduct;
        }
    }
}
