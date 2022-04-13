using System;

namespace myDemo2
{
    class BillingAddress
    {
        //
    }
    class Person
    {
        string firstName;
        string lastName;
        int age;
        string birthDate;

        public void SetPersonDetails()
        {
            Console.WriteLine("Enter First Name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter Age: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Birth Date: ");
            birthDate = Console.ReadLine();
        }
        public void DisplayDetails()
        {
            Console.WriteLine("Full Name: {0} {1}", lastName, firstName);
            Console.WriteLine("Age: {0}", age);
            Console.WriteLine("Birth Date: {0}", birthDate);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.SetPersonDetails();
            person.DisplayDetails();
        }
    }
}
