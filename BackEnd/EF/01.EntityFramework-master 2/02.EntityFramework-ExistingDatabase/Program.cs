using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text.Json;

namespace EntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var weatherClientConfig = ConfigurationHelper.GetInstance().GetConfiguration<WeatherClientConfig>();
            Console.WriteLine(JsonSerializer.Serialize(weatherClientConfig));
            var connectionString = ConfigurationHelper.GetInstance().GetProperty<string>("DbConnectionString");

            using (var context = new OnlineShopContext(connectionString))
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

                context.SaveChanges();
            }

            Console.WriteLine("Executed successfully.");
        }
    }
}
