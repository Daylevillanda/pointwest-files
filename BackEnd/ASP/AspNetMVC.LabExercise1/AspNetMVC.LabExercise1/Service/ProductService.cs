using AspNetMVC.LabExercise1.Models;
using System.Collections.Generic;

namespace AspNetMVC.LabExercise1.Service
{
    public class ProductService
    {
        private List<Product> products;
        public ProductService()
        {
            this.products = new List<Product>();
            products.Add(new Product()
            {
                Id = 1,
                Name = "Iphone 6",
                Description = "Iphone 6S model",
                Quantity = 5,
                Price = 50_000M
            });
            products.Add(new Product()
            {
                Id = 2,
                Name = "Samsung Galaxy",
                Description = "Samsung Flip model",
                Quantity = 7,
                Price = 90_000M
            });
            products.Add(new Product()
            {
                Id = 3,
                Name = "Samsung Galaxy Fold",
                Description = "Samsung Fold model",
                Quantity = 10,
                Price = 80_000M
            });
            products.Add(new Product()
            {
                Id = 1,
                Name = "Keyboard",
                Description = "Razor Keyboard",
                Quantity = 2,
                Price = 8_000M
            });
            products.Add(new Product()
            {
                Id = 1,
                Name = "Iphone 12",
                Description = "Iphone 12 Pro model",
                Quantity = 4,
                Price = 120_000M
            });
        }

        public List<Product> GetCatalog()
        {
            return products;
        }
       

        public decimal GetGrandTotal()
        {
            decimal total = 0;
            foreach (var product in products)
            {
                total += product.TotalPrice;
            }
            return total;
        }
    }
}
