using EF.GenericRepository.myDemo.Data;
using EF.GenericRepository.myDemo.Models;
using EF.GenericRepository.myDemo.Repositories;
using System;
using System.Linq;

namespace EF.GenericRepository.myDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationHelper configurationHelper = ConfigurationHelper.Instance();
            var dbConnectionString = configurationHelper.GetProperty<string>("DbConnectionString");
            Console.WriteLine(dbConnectionString);
            using (OnlineShopContext context = new OnlineShopContext(dbConnectionString))
            {
                ProductGenericRepository productGenericRepository = new ProductGenericRepository(context);

                int num = 1;
                foreach (var count in Enumerable.Range(1, 5))
                {
                    var product = new Product
                    {
                        Name = "Some Product" + count,
                        Price = 1500M + count,
                        ProductCode = "P000" + num.ToString()
                    };
                    var persistedProduct = productGenericRepository.Save(product);
                    num++;
                }
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
