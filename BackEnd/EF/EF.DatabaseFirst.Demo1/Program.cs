using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using EF.DatabaseFirst.Demo1.Data;
using EF.DatabaseFirst.Demo1.Models;
using EF.DatabaseFirst.Demo1.Repositories;
using System.Linq;

namespace EF.DatabaseFirst.Demo1
{
    class PaypalApi
    {
        public string Url { get; set; }
        public string Token { get; set; }
    }

    class PaymayaApi
    {
        public string Url { get; set; }
        public string Token { get; set; }
    }

    class Program
    {
        static Product AddTest(ProductRepository repository)
        {
            var product1 = new Product
            {
                Name = "Some Product",
                Price = 1500M,
                ProductCode = "P0001"
            };
            var persistedProduct1 = repository.Save(product1);
            return persistedProduct1;
        }

        static List<int> AddMultipleTest(ProductRepository repository)
        {
            List<int> generatedIds = new List<int>();
            var num = 1;
            foreach (var value in Enumerable.Range(1, 5))
            {
                var product = new Product
                {
                    Name = "Some Product " + value,
                    Price = 1500M,
                    ProductCode = "P000" + num.ToString()
                };
                var persistedProduct = repository.Save(product);
                generatedIds.Add(persistedProduct.Id);
                num++;
            }

            return generatedIds;
        }

        static Product FindByIdTest(int id, ProductRepository repository)
        {
            return repository.FindById(id);
        }

        static Product UpdateTest(int id, ProductRepository repository)
        {
            try
            {
                var existingProduct = repository.FindById(id);

                existingProduct.Price += 500;
                var updatedProduct = repository.Update(existingProduct);
                return updatedProduct;

            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                Console.WriteLine($"Product with ID {id} successfully deleted.");
            }
        }
        static void Main(string[] args)
        {
            ConfigurationHelper configurationHelper = ConfigurationHelper.Instance();
            var dbConnectionString = configurationHelper.GetProperty<string>("DbConnectionString");

            using (OnlineShopContext context = new OnlineShopContext(dbConnectionString))
            {
                ProductRepository repository = ProductRepository.Instance(context);

                // Product newProduct = AddTest(repository);
                // Console.WriteLine($"AddTest: {newProduct.Id}");

                //List<int> generatedIds = AddMultipleTest(repository);   
                //string generatedIdString = String.Join(" ", generatedIds);
                //Console.WriteLine($"AddMultipleTest: {generatedIdString}");

                /*try
                {
                    Product existingProduct = FindByIdTest(100, repository);
                    Console.WriteLine($"FindByIdTest: {existingProduct.Name} - {existingProduct.Price}");
                } 
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }*/

                /*try
                {
                    Product existingProduct = UpdateTest(1, repository);
                    Console.WriteLine($"FindByIdTest: {existingProduct.Name} - {existingProduct.Price}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }*/

                /*try
                {
                    Product existingProduct = DeleteTest(1, repository);
                    Console.WriteLine($"FindByIdTest: {existingProduct.Name} - {existingProduct.Price}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }*/

                List<int> generatedIds = AddMultipleTest(repository);
                string generatedIdString = String.Join(" ", generatedIds);
                Console.WriteLine($"Generated IDs: {generatedIdString}");
                DeleteMultipleTest(generatedIds, repository);

            }

            Console.WriteLine($"Success {dbConnectionString}");

            //var apiKey = configurationHelper.GetProperty<string>("ApiKey");
            //Console.WriteLine(apiKey);
            //var apiUrl = configurationHelper.GetProperty<string>("ApiUrl");
            //Console.WriteLine(apiUrl);

            //var paypalApi = configurationHelper.GetConfiguration<PaypalApi>();
            //Console.WriteLine(paypalApi.Url);
            //Console.WriteLine(paypalApi.Token);

            //var paymayaApi = configurationHelper.GetConfiguration<PaymayaApi>();
            //Console.WriteLine(paymayaApi.Url);
            //Console.WriteLine(paymayaApi.Token);


            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .AddUserSecrets<Program>().Build();

            //var dbConnectionString = configuration
            //    .GetValue<string>("DBConnectionString");

            //var apiKey = configuration
            //    .GetValue<string>("ApiKey");

            //var apiUrl = configuration
            //    .GetValue<string>("ApiUrl");

            //Console.WriteLine(dbConnectionString);
            //Console.WriteLine(apiKey);
            //Console.WriteLine(apiUrl);

            //var paypalApiConfig = configuration
            //    .GetSection(typeof(PaypalApi).Name);
            //Console.WriteLine(JsonSerializer.Serialize(paypalApiConfig));
            //Console.WriteLine(paypalApiConfig.GetValue<string>("Url"));

            //var paymayaApiConfig = configuration
            //    .GetSection(typeof(PaymayaApi).Name);
            //Console.WriteLine(JsonSerializer.Serialize(paymayaApiConfig));
            //Console.WriteLine(paymayaApiConfig.GetValue<string>("Url"));
            //Console.WriteLine(paymayaApiConfig.GetValue<string>("Token"));
        }
    }
}
