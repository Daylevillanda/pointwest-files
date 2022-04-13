using System;

namespace CSharp.Demo3b
{
    // Properties - Getter & Setter
    // Fields

    class Product
    {

        int quantity;

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity should be greater than zero.");
                }
                this.quantity = value;
            }
        }


        public void SetQuantity(int quantity)
        {
            this.quantity = quantity;
        }


        public int GetQuantity()
        {
            return this.quantity;
        }

        // Computed Property
        public decimal TotalPrice
        {
            get
            {
                return Price * Quantity;
            }
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Product ID: {0}", this.Id);
            Console.WriteLine("Product Name: {0}", this.Name);
            Console.WriteLine("Product Price: {0}", this.Price);
            Console.WriteLine("Product Quantity: {0}", this.Quantity);
            Console.WriteLine("Product Total Price: {0}", this.TotalPrice);
        }

        public void GetDetails()
        {
            Console.Write("Enter Product ID: ");
            this.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Product Name: ");
            this.Name = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            this.Price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Product Quantity: ");
            this.Quantity = Convert.ToInt32(Console.ReadLine());
        }
    }

    class Person
    {
        string firstName; // field
        string lastName;  // field
        
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if(value == null || value.Trim().Length == 0)
                {
                    throw new ArgumentException("Invalid First Name.");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public string FullName
        {
            get
            {
                return $"{lastName}, {firstName}";
            }
            private set { }
        }

        public int Age { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product
            {
                Id = 0,
                Name = "",
                Price = 100,
                Quantity = 1
            };

            Product product1 = new Product();
            product1.Id = 0;
            product1.Name = "";
            product1.Price = 1000;
            product1.Quantity = 1;

            product.GetDetails();
            product.DisplayDetails();

        }
    }
}

