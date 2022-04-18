using System;

namespace CSharp.Demo7c
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"{FirstName}, {LastName}, {Age}");
        }
    }

    class Employee: Person
    {
        public string ID { get; set; }
        public string SSSNumber { get; set; }
        public decimal Salary { get; set; }

        public override void DisplayDetails()
        {
            Console.WriteLine($"{ID}, {SSSNumber}, {Salary}");
            base.DisplayDetails();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee
            {
                ID = "1001",
                FirstName = "John",
                LastName = "Doe",
                Age = 55,
                SSSNumber = "1234567890",
                Salary = 15_000M
            };

            employee.DisplayDetails();
        }
    }
}

