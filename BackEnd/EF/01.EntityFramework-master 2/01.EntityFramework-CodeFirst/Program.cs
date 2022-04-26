using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EntityFrameworkDemo
{
    class Program
    {
        static void AddProducts(OnlineShopContext context)
        {
            var product1 = new Product
            {
                Name = "iPhone 13",
                Price = 90_000M
            };
            context.Products.Add(product1);

            var product2 = new Product
            {
                Name = "PS4",
                Price = 50_000M
            };
            context.Products.Add(product2);
        }

        static void DisplayProducts(IEnumerable<Product> products)
        {
            foreach (Product p in products)
            {
                Console.WriteLine($"ID: {p.Id}, Name: ${p.Name}, Price: {p.Price}");
            }
        }

        static IEnumerable<Product> ProductsQueryUsingFluent(OnlineShopContext context)
        {
            IEnumerable<Product> products = context.Products.Where(p => p.Price > 40_000M).OrderBy(p => p.Name).AsEnumerable();
            return products;
        }

        static void UpdateProduct(OnlineShopContext context)
        {
            var iphone = context.Products.Where(p => p.Name == "iPhone 13").FirstOrDefault();
            if (iphone is Product)
            {
                iphone.Price = 120_000M;
                context.SaveChanges();
                Console.WriteLine("iPhone 13 price updated.");
            }
            else
            {
                Console.WriteLine("No iPhone 13 found.");
            }
        }

        static IEnumerable<Product> ProductsQueryUsingLinq(OnlineShopContext context)
        {
            var products = from product in context.Products
                           where product.Price > 40_000M
                           orderby product.Name
                           select product;

            return products;
        }

        static void RemoveProducts(OnlineShopContext context)
        {
            /*var iphone = context.Products.Where(p => p.Name == "iPhone 13").FirstOrDefault();
            if (iphone is Product)
            {
                context.Remove(iphone);
                context.SaveChanges();
                Console.WriteLine("iPhone 13 deleted.");
            }
            else
            {
                Console.WriteLine("No iPhone 13 found.");
            }*/

            context.Products.RemoveRange(context.Products.Where(p => p.Name == "iPhone 13"));
            context.Products.RemoveRange(context.Products.Where(p => p.Name == "PS4"));
            context.SaveChanges();
        }

        static void Main(string[] args)
        {
            using (var context = new OnlineShopContext())
            {
                AddProducts(context);
                DisplayProducts(ProductsQueryUsingFluent(context));
                UpdateProduct(context);
                DisplayProducts(ProductsQueryUsingLinq(context));
                RemoveProducts(context);
            }

            Console.WriteLine("Executed successfully.");
        }
    }
}
