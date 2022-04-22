using System;
using EntityFramework.Demo1a.Data;
using EntityFramework.Demo1a.Models;
using System.Linq;

namespace EntityFramework.Demo1a
{
    internal class Program
    {
        static void AddProducts(OnlineShopContext context)
        {
            var iphone = new Product
            {
                Name = "Iphone 14",
                Price = 150_000M
            };
            context.Products.Add(iphone);

            var ps4 = new Product
            {
                Name = "Sony PS4",
                Price = 50_000M
            };
            context.Products.Add(ps4);

            //save all transaction
            context.SaveChanges();
        }
        static void DisplayProducts(OnlineShopContext context)
        {
            //Linq to entities
            var products = from product in context.Products
                           orderby product.Name
                           select product;
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
        }
        static void Main(string[] args)
        {
            using(OnlineShopContext context = new OnlineShopContext())
            {
                //DisplayProducts(context);
                AddProducts(context);
            };
            Console.WriteLine("Transaction committed successfully");
        }
    }
}
