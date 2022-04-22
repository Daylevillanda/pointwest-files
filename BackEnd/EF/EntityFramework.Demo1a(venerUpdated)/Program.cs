using System;
using EntityFramework.Demo1a.Data;
using EntityFramework.Demo1a.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Demo1a.Repositories;
using EntityFramework.Demo1a.Exceptions;


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
            catch(Exception e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Message);
            }
           
        }

        static void DisplayProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, ProductCode: {product.ProductCode}");
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

            IEnumerable<Product> products = context.Products
                                                   .Where(p => p.Price > 500 && p.Price < 2000)
                                                   .OrderByDescending(p => p.Price)
                                                   .AsEnumerable();
            return products;
        }

        static void UpdateProduct(int id, decimal newPrice, OnlineShopContext context)
        {
            var existingProduct = context.Products.Where(p => p.Id == id).FirstOrDefault();
            if (existingProduct is Product)
            {
                existingProduct.Price = newPrice;
                context.SaveChanges();
                Console.WriteLine($"Product {id} price successfully updated.");
            }
            else
            {
                Console.WriteLine($"No product found: {id}");
            }
        }

        static void RemoveProduct(int id, OnlineShopContext context)
        {
            var existingProduct = context.Products.Where(p => p.Id == id).FirstOrDefault();
            if (existingProduct is Product)
            {
                context.Remove(existingProduct);
                context.SaveChanges(true);
                Console.WriteLine($"Product {id} successfully deleted.");
            }
            else
            {
                Console.WriteLine($"No product found: {id}");
            }
        }

        static void Main(string[] args)
        {
            using (OnlineShopContext context = new OnlineShopContext())
            {
                //AddProducts(context);
                //DisplayProducts(GetProductsByLinq(context)); 
                //DisplayProducts(GetProductsByQueryApi(context));
                //UpdateProduct(1, 25_000M, context);
                //RemoveProduct(2, context);
                ProductRepository productRepository = ProductRepository.Instance(context);

                try
                {
                    var existingProduct = productRepository.FindByCode("P0001");
                    existingProduct.Price += 1000;
                    productRepository.Update(existingProduct);
                    Console.WriteLine("Product details successfully updated.");

                    /*var iphone = new Product
                    {
                        Name = "iPhone 14",
                        Price = 150_000M,
                        ProductCode = "P0002"
                    };
                    productRepository.Insert(iphone);

                    var ps4 = new Product
                    {
                        Name = "Sony PS4",
                        Price = 50_000,
                        ProductCode = "P0003"
                    };
                   productRepository.Insert(ps4);*/
                    productRepository.Delete(4);
                }
                catch (DataAccessException e)
                {
                    Console.WriteLine(e.Message);
                }


            }
            Console.WriteLine("Transaction committed successfully");
        }
    }
}
