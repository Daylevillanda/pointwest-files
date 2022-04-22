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
        private OnlineShopContext _context;
        public static ProductRepository INSTANCE;
        private ProductRepository(OnlineShopContext context)
        {
            this._context = context;
        }
        public static ProductRepository Instance(OnlineShopContext context)
        {
            if(INSTANCE == null)
            {
                INSTANCE = new ProductRepository(context);
            }
            return INSTANCE;
        }

        public Product FindById(int id)
        {
            var product = _context.Products.Find(id);
            if(product != null)
            {
                return product;
            }
            else
            {
                throw DataAccessException.Instance($"Entity with ID {id} is not found");
            }
        }
        public List<Product> FindAll()
        {
            return _context.Products.ToList();
        }

        public List<Product> FindByPrice(decimal minimumPrice, decimal maximumPrice)
        {
            var products = _context.Products
                .Where(x => x.Price >= minimumPrice && x.Price <= maximumPrice);

            return products.ToList();
        }

        public List<Product> FindByName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw DataAccessException.Instance("Name cannot be null");
            }
            var products = _context.Products
                .Where(x => x.Name.Equals(name));

            return products.ToList();
        }

        public List<Product> SearchByName(string name)
        {
            var products = _context.Products
                .Where(x => x.Name.Contains(name));

            return products.ToList();
        }

        public Product FindByCode(string code)
        {
            var product = _context.Products.Where(x => x.ProductCode.Equals(code)).Single();
            if (product != null)
            {
                return product;
            }
            else
            {
                throw DataAccessException.Instance($"Entity with Code {code} is not found");
            }
        }

        public void Insert(Product product)
        {
            if(product == null)
            {
                throw DataAccessException.Instance("Product cannot be null");
            }

            var existingProduct = _context.Products.Where(x => x.ProductCode.Equals(product.ProductCode)).FirstOrDefault();

            if (existingProduct is Product)
            {
                throw DataAccessException.Instance("Product already exist");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            if (product == null)
            {
                throw DataAccessException.Instance("Product cannot be null");
            }

            var existingProduct = CheckProductExistence(product.Id);

            _context.Products.Attach(product);
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {            
            var existingProduct = CheckProductExistence(id);
            _context.Products.Remove(existingProduct);
            _context.SaveChanges();
        }

        public Product CheckProductExistence(int id)
        {
            var product = _context.Products.Find(id);
            if (product is not Product)
            {
                throw DataAccessException.Instance("Product does not exist");
            }
            return product;
        }
    }
}
