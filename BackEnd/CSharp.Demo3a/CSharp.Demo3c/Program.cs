using System;

namespace CSharp.Demo3c
{
    // Method/Constructor Overloading
    // - same method name
    // - number of parameters
    // - parameter type

    // code smell - duplicate statements

    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Customer(): this(0, "N/A", "N/A", -1)
        {
        }

        public Customer(int id): this(id, "N/A", "N/A", -1)
        {
        }

        public Customer(int id, string firstName, string lastName): this(id, firstName, lastName, -1)
        {
        }

        public Customer(int id, string firstName, string lastName, int age)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

    }

    class Calculator
    {
        public void Add(string x, string y)
        {
            decimal num1 = Convert.ToInt32(x);
            decimal num2 = Convert.ToInt32(y);
            this.Add(num1, num2, 0);
        }

        public void Add(int x, int y)
        {
            this.Add((decimal)x, (decimal)y, 0);
        }

        public void Add(decimal x, decimal y)
        {
            this.Add(x, y, 0M);
        }

        public void Add(decimal x, decimal y, decimal z)
        {
            Console.WriteLine("Sum: {0}", (x + y + z));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer(1);

            Calculator calculator = new Calculator();

            calculator.Add(1M, 2M);
        }
    }
}

