using System;
using EntityFramework.Demo1a.Data;
using EntityFramework.Demo1a.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Demo1a
{
    internal class Program
    {
        static void AddProducts(OnlineShopContext context)
        {
            var iphone = new Product
            {
                Name = "iPhone 14",
                Price = 150_000M,
                ProductCode = "P0001"
            };
            context.Products.Add(iphone);

            var ps4 = new Product
            {
                Name = "Sony PS4",
                Price = 50_000,
                ProductCode = "P0002"
            };
            context.Products.Add(ps4);

            try
            {
                context.SaveChanges();
            }
            //catch (DbUpdateConcurrencyException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //catch (DbUpdateException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Message);
            }

        }        

        static void DisplayProducts(IEnumerable<Product> products)
        {
            foreach (var p in products)
            {
                Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Price: {p.Price}, ProductCode: {p.ProductCode}");
            }

        }

        static IEnumerable<Product> GetProductsByLinq(OnlineShopContext context)
        {
            // linq to entities
            var products = from product in context.Products
                           orderby product.Name
                           select product;
            return products;
        }

        static IEnumerable<Product> GetProductsByQueryApi(OnlineShopContext context)
        {
            //fluent query
            IEnumerable<Product> products = context.Products
                .Where(p => p.Price > 500 && p.Price < 2000)
                .OrderByDescending(p => p.Price)
                .AsEnumerable(); //.ToList()

            return products;
        }
        static void UpdateProduct(int id, decimal newPrice, OnlineShopContext context)
        {
            var existingProduct = context.Products
                .Where(p => p.Id == id)
                .FirstOrDefault();
            if(existingProduct is Product)
            {
                existingProduct.Price = newPrice;
                context.SaveChanges();
                Console.WriteLine($"Product {id} price successfuly updated");

            }
            else
            {
                Console.WriteLine($"No product found: {id}");
            }
        }
        static void DeleteProduct(int id, OnlineShopContext context)
        {
            var existingProduct = context.Products
                .Where(p => p.Id == id)
                .FirstOrDefault();
            if (existingProduct is Product)
            {
                context.Remove(existingProduct);
                context.SaveChanges();
                Console.WriteLine($"Product {id} successfuly deleted");

            }
            else
            {
                Console.WriteLine($"No product found: {id}");
            }
        }
        static void Main(string[] args)
        {
           using(OnlineShopContext context = new OnlineShopContext())
           {
                //AddProducts(context);
                //DisplayProducts(GetProductsByLinq(context));
                //DisplayProducts(GetProductsByQueryApi(context));
                //UpdateProduct(1, 500, context);
                //DeleteProduct(1, context);
            }
           Console.WriteLine("Transaction committed successfully");
        }
    }
}
