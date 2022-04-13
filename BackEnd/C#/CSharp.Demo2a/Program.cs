using System;

namespace CSharp.Demo2a
{
    class Person
    {
        // global scope/instance variables
        string firstName;
        string lastName;
        int age;
        string birthDate;

        public void SetPersonDetails()
        {
            Console.Write("Enter first name: ");
            firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            lastName = Console.ReadLine();
            Console.Write("Enter age: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter birth date: ");
            birthDate = Console.ReadLine();
        }

        public void DisplayDetails()
        {
            // string fullName = lastName + ", " + firstName;
            string fullName = String.Format("{0}, {1}", lastName, firstName);
            string url = String.Format("https://{0}.{1}.com", "test", "paypal");


            Console.WriteLine("Full Name: {0}, {1}", lastName, firstName);
            Console.WriteLine("Age: {0}", age);
            Console.WriteLine("Birth Date: {0}", birthDate);
        }
    }

    class Program
    {
        static void Main(string[] parameters)
        {
                   // reference
            Person veryImportantPerson = new Person();
            veryImportantPerson.SetPersonDetails();
            veryImportantPerson.DisplayDetails();
        }
    }
}

