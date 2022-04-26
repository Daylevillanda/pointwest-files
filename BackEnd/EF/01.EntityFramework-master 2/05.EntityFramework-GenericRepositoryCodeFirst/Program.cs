using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Models;
using EntityFrameworkDemo.Repositories;
using System;

namespace EntityFrameworkDemo
{
    class Program
    {
        static Product AddTest(IUnitOfWork unitOfWork)
        {
            var product = new Product
            {
                Name = "iPhone 13",
                Price = 90_000M
            };

            var persistedProduct = unitOfWork.ProductRepository.Insert(product);
            unitOfWork.Commit();
            return persistedProduct;
        }

        static void Main(string[] args)
        {
            var context = new OnlineShopContext();
            var unitOfWork = new UnitOfWork();

            var newProduct = AddTest(unitOfWork);
            Console.WriteLine($"AddTest: {newProduct.Id}");

            unitOfWork.ProductRepository.Delete(Guid.Parse(newProduct.Id.ToString()));
            unitOfWork.Commit();


        }
    }
}
