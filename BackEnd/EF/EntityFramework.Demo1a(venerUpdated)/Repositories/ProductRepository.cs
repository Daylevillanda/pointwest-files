using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Demo1a.Data;
using EntityFramework.Demo1a.Models;
using EntityFramework.Demo1a.Exceptions;

namespace EntityFramework.Demo1a.Repositories
{
    public class ProductRepository
    {
        private static ProductRepository INSTANCE;

        private OnlineShopContext context;


        public static ProductRepository Instance(OnlineShopContext context)
        {
            if(INSTANCE == null)
            {
                INSTANCE = new ProductRepository(context);
            }
            return INSTANCE;
        }

        private ProductRepository(OnlineShopContext context)
        {
            this.context = context;
        }

        public Product FindById(int id)
        {
            var product = context.Products.Find(id);
            if(product != null)
            {
                return product;
            }

            throw DataAccessException.instance($"Entity with ID {id} not found.");
        }

        public List<Product> FindAll()
        {
            return context.Products.ToList(); 
        }

        public List<Product> FindByPrice(decimal minimumPrice, decimal maximumPrice)
        {
            var products = context.Products.Where(x => x.Price >= minimumPrice && x.Price <= maximumPrice).ToList();
            return products;
        }

        public List<Product> FindByName(string name)
        {
            var products = context.Products.Where(x => x.Name.Equals(name)).ToList();
            return products;
        }

        public Product FindByCode(string code)
        {
            var product = context.Products.Where(x => x.ProductCode.Equals(code)).Single();
            if(product != null)
            {
                return product;
            }
            throw DataAccessException.instance($"Entity with code {code} not found.");
        }
        public void Insert(Product product)
        {
            if(product == null)
            {
                throw DataAccessException.instance("Product is null.");
            }
            var existingProduct = context.Products.Where(x => x.ProductCode.Equals(product.ProductCode)).FirstOrDefault();
            if (existingProduct is Product)
            {
                throw DataAccessException.instance("Product already existing.");
            }
            context.Products.Add(product);
            context.SaveChanges();
        }

       

        public void Update(Product product) // transient
        {
            if (product == null)
            {
                throw DataAccessException.instance("Product cannot be null.");
            }

            CheckProductExistence(product.Id);

            context.Products.Attach(product);
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var existingProduct = CheckProductExistence(id);

            context.Products.Remove(existingProduct);
            context.SaveChanges();
        }

        private Product CheckProductExistence(int id)
        {
            var existingProduct = context.Products.Where(p => p.Id.Equals(id)).FirstOrDefault();
            if (existingProduct == null)
            {
                throw DataAccessException.instance($"Product doesn't exist. {existingProduct.Id}");
            }
            return existingProduct;
        }
    }
}
