using _02.SessionCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02.SessionCart.Services
{
    public class ProductService
    {
        private List<Product> products;

        public ProductService()
        {
            this.products = new List<Product>() {
                new Product {
                    Id = "p01",
                    Name = "Name 1",
                    Price = 5,
                    Photo = "thumb1.jpg"
                },
                new Product {
                    Id = "p02",
                    Name = "Name 2",
                    Price = 2,
                    Photo = "thumb2.jpg"
                },
                new Product {
                    Id = "p03",
                    Name = "Name 3",
                    Price = 6,
                    Photo = "thumb3.jpg"
                }
            };
        }

        public List<Product> FindAll()
        {
            return this.products;
        }

        public Product Find(string id)
        {
            return this.products.Single(p => p.Id.Equals(id));
        }
    }
}