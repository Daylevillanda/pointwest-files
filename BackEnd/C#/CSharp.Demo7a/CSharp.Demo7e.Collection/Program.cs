using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.Demo7e.Collection
{
    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return Price * Quantity;
            }
        }

        public override string ToString()
        {
            return $"{ID}, {Name}, {Price}, {Quantity}, {TotalPrice}";
        }
    }

    class Cart
    {
        private List<Product> items;

        public Cart()
        {
            items = new List<Product>();
        }

        public void AddToCart(Product product)
        {
            items.Add(product);
        }

        public decimal CalculateTotalAmoount()
        {
            decimal totalAmount = 0M;
            foreach(var existingProduct in items)
            {
                totalAmount += existingProduct.TotalPrice;
            }
            return totalAmount;
        }

        public void DisplayItems()
        {
            foreach (var existingProduct in items)
            {
                Console.WriteLine($"~~ {existingProduct.ToString()}");
            }
        }

        public List<Product> CartItems { get { return this.items; } }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cart = new Cart();

            var answer = "y";
            while (answer.Trim().ToLower().Equals("y"))
            {
                var product = new Product();

                Console.Write("Enter Product ID: ");
                product.ID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Product Name: ");
                product.Name = Console.ReadLine();

                Console.Write("Enter Product Price: ");
                product.Price = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter Product Quantity: ");
                product.Quantity = Convert.ToInt32(Console.ReadLine());

                cart.AddToCart(product);

                Console.Write("Do you want to continue(y/n)? ");
                answer = Console.ReadLine();
            }

            cart.DisplayItems();
            Console.WriteLine("~~ =====================");
            Console.WriteLine($"~~ Total Amount: {cart.CalculateTotalAmoount()}");
        }
    }
}

