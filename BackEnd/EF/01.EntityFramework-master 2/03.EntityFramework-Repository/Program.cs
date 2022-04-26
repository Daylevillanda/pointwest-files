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
        static Product AddTest(ProductRepository repository)
        {
            var product = new Product
            {
                Name = "iPhone 13",
                Price = 90_000M
            };

            var persistedProduct = repository.Save(product);
            return persistedProduct;
        }

        static List<int> AddMultipleTest(ProductRepository repository)
        {
            List<int> generatedIds = new List<int>();

            foreach (int value in Enumerable.Range(1, 10))
            {
                var product = new Product
                {
                    Name = "iPhone 13",
                    Price = 90_000M
                };
                var persistedProduct = repository.Save(product);
                generatedIds.Add(persistedProduct.Id);
            }
            return generatedIds;
        }

        static Product FindByPrimarKeyTest(int id, ProductRepository repository)
        {
            return repository.FindByPrimaryKey(id);
        }

        static Product UpdateTest(int id, ProductRepository repository)
        {
            var existingProduct = repository.FindByPrimaryKey(id);
            if (existingProduct is object)
            {
                existingProduct.Price = 150_000M;
                var updatedProduct = repository.Update(existingProduct);
                return updatedProduct;
            }

            throw new Exception($"Product not found {id}");
        }

        static Product DeleteTest(int id, ProductRepository repository)
        {
            return repository.Delete(id);
        }

        static void DeleteMultipleTest(List<int> ids, ProductRepository repository)
        {
            foreach (var id in ids)
            {
                repository.Delete(id);
            }
        }

        static IEnumerable<Product> FindAllTest(ProductRepository repository)
        {
            return repository.FindAll();
        }

        static void Main(string[] args)
        {
            var connectionString = ConfigurationHelper.GetInstance().GetProperty<string>("DbConnectionString");
            Console.WriteLine($"Connection String: {connectionString}");

            using (var context = new OnlineShopContext(connectionString))
            {
                var repository = new ProductRepository(context);

                Product newProduct = AddTest(repository);
                Console.WriteLine($"AddTest: {newProduct.Id}");

                List<int> generatedIds = AddMultipleTest(repository);
                string generatedIdsString = String.Join(" ", generatedIds);
                Console.WriteLine($"AddMultipleTest: {generatedIdsString}");

                var existingProduct = FindByPrimarKeyTest(newProduct.Id, repository);
                Console.WriteLine($"FindByPrimaryKeyTest: {existingProduct is object}");

                var updatedProduct = UpdateTest(newProduct.Id, repository);
                Console.WriteLine($"UpdateTest: {updatedProduct is object} {newProduct.Price == updatedProduct.Price}");

                var deletedProduct = DeleteTest(updatedProduct.Id, repository);
                Console.WriteLine($"DeleteTest: {deletedProduct.Id}");

                DeleteMultipleTest(generatedIds, repository);
                Console.WriteLine($"DeleteMultipleTest: {deletedProduct.Id}");

                var products = FindAllTest(repository);
                Console.WriteLine($"FindAllTest: {products.Count() == 0}");

            }
        }
    }
}
