using System;
using System.Linq;

namespace CSharp.Demo3d
{
    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, string description, decimal price, int quantity)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string GetProductDetailsAsString()
        {
            return $"ID={this.ID}, Name={this.Name}, Description={this.Description}, Price={this.Price}, Quantity={this.Quantity}";
        }
    }

    class ProductCatalog
    {
        Product[] products;

        public ProductCatalog()
        {
            products = new Product[]
            {
                new Product
                {
                    ID = 1,
                    Name = "Mobile Phone",
                    Description = "Smart Phone",
                    Price = 15_000M,
                    Quantity = 10
                },
                new Product
                {
                    ID = 2,
                    Name = "Phone Case",
                    Description = "Shockproof Phone Case",
                    Price = 200M,
                    Quantity = 150
                },
                new Product
                {
                    ID = 3,
                    Name = "Coffee Mug",
                    Description = "Cheap but durable coffee mug",
                    Price = 350M,
                    Quantity = 50
                }
            };
        }

        public Product[] Items
        {
            get
            {
                return products;
            }
        }

        public Product FindById(int id)
        {
            return products.Single(p => p.ID == id);
        }
    }

    class ProductCatalogRenderer
    {
        ProductCatalog productCatalog;

        public ProductCatalogRenderer(ProductCatalog productCatalog)
        {
            this.productCatalog = productCatalog;
        }

        public void DisplayCatalog()
        {
            foreach (var product in productCatalog.Items)
            {
                Console.WriteLine(product.GetProductDetailsAsString());
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ProductCatalog productCatalog = new ProductCatalog();
            ProductCatalogRenderer productCatalogRenderer = new ProductCatalogRenderer(productCatalog);
            productCatalogRenderer.DisplayCatalog();
        }
    }
}

