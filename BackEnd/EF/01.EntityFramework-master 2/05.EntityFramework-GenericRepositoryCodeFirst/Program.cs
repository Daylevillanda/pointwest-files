using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Models;
using EntityFrameworkDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    class Program
    {
        static async Task AddUsingAsync()
        {
            var context = new OnlineShopContext();
            ProductRepository productRepository = new ProductRepository(context);
            var product = new Product
            {
                Name = "some123456",
                Price = 90_000M
            };
            var persistedProduct = productRepository.Insert(product);

            await context.SaveChangesAsync();
        }
        static Product AddTest(IUnitOfWork unitOfWork)
        {
            var product = new Product
            {
                Name = "samsung12345",
                Price = 90_000M
            };

            var persistedProduct = unitOfWork.ProductRepository.Insert(product);
            //unitOfWork.CommitAsync(); ->original
            //unitOfWork.Commit();

            //In console app
            Task t = unitOfWork.CommitAsync();
            t.Wait(); //you need this to work with async and await in console app
            
            return persistedProduct;
        }
        static void Main(string[] args)
        {
            var context = new OnlineShopContext();
            var unitOfWork = new UnitOfWork(context);

            var newProduct = AddTest(unitOfWork);
            Console.WriteLine($"AddTest: {newProduct.Id}");

            //unitOfWork.ProductRepository.Delete(Guid.Parse(newProduct.Id.ToString()));
            //unitOfWork.Commit();
        }
    }
}
