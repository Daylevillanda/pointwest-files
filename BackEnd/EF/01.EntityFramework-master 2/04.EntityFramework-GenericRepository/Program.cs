using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Models;
using EntityFrameworkDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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

        static List<int> AddMultipleTest(IUnitOfWork unitOfWork)
        {
            List<int> generatedIds = new List<int>();

            foreach (int value in Enumerable.Range(1, 10))
            {
                var product = new Product
                {
                    Name = "iPhone 13",
                    Price = 90_000M
                };
                var persistedProduct = unitOfWork.ProductRepository.Insert(product);
                unitOfWork.Commit();

                generatedIds.Add(persistedProduct.Id);
            }


            return generatedIds;
        }

        static Product FindByPrimarKeyTest(int id, UnitOfWork unitOfWork)
        {
            return unitOfWork.ProductRepository.FindByPrimaryKey(id);
        }

        static Product UpdateTest(int id, IUnitOfWork unitOfWork)
        {
            var existingProduct = unitOfWork.ProductRepository.FindByPrimaryKey(id);
            if (existingProduct is object)
            {
                existingProduct.Price = 150_000M;
                var updatedProduct = unitOfWork.ProductRepository.Update(existingProduct);
                return updatedProduct;
            }
            unitOfWork.Commit();

            throw new Exception($"Product not found {id}");
        }

        static Product DeleteTest(int id, IUnitOfWork unitOfWork)
        {
            var product = unitOfWork.ProductRepository.Delete(id);
            unitOfWork.Commit();

            return product;
        }

        static void DeleteMultipleTest(List<int> ids, IUnitOfWork unitOfWork)
        {
            foreach (var id in ids)
            {
                unitOfWork.ProductRepository.Delete(id);
            }

            unitOfWork.Commit();
        }

        static IEnumerable<Product> FindAllTest(UnitOfWork unitOfWork)
        {
            return unitOfWork.ProductRepository.FindAll();
        }

        static void Main(string[] args)
        {
            var connectionString = ConfigurationHelper.GetInstance().GetProperty<string>("DbConnectionString");
            Console.WriteLine($"Connection String: {connectionString}");

            var unitOfWork = new UnitOfWork();

            Product newProduct = AddTest(unitOfWork);
            Console.WriteLine($"AddTest: {newProduct.Id}");


            List<int> generatedIds = AddMultipleTest(unitOfWork);
            string generatedIdsString = String.Join(" ", generatedIds);
            Console.WriteLine($"AddMultipleTest: {generatedIdsString}");

            var existingProduct = FindByPrimarKeyTest(newProduct.Id, unitOfWork);
            Console.WriteLine($"FindByPrimaryKeyTest: {existingProduct is object}");

            var updatedProduct = UpdateTest(newProduct.Id, unitOfWork);
            Console.WriteLine($"UpdateTest: {updatedProduct is object} {newProduct.Price == updatedProduct.Price}");


            var deletedProduct = DeleteTest(updatedProduct.Id, unitOfWork);
            Console.WriteLine($"DeleteTest: {deletedProduct.Id}");

            DeleteMultipleTest(generatedIds, unitOfWork);
            Console.WriteLine($"DeleteMultipleTest: {deletedProduct.Id}");

            var products = FindAllTest(unitOfWork);
            Console.WriteLine($"FindAllTest: {products.Count() == 0}");
        }
    }
}
