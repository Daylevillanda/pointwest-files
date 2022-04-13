using System;

namespace CSharp.Demo5c
{

    // const vs static vs readonly
    // sealed vs abstract
    abstract class Person
    {
        // field/instance variable
        const string status = "alive";

        readonly string DB_HOST;

        public Person()
        {
            DB_HOST = "username";
        }

        public void Display()
        {
            // local variable
            const int numberOfQuestions = 25;
        }
    }

    class DatabaseConstants
    {
        public const string DB_USERNAME = "sa";
        public const string DB_PASSWORD = "password";
        public const string DB_HOST = "localhost";
    }

    class StringValidator
    {
        public const string DATABASE_CONNECTION_URL = "localhost:1433/schema";

        public static Boolean IsNullOrEmpty(string value)
        {
            return value == null || value.Trim().Equals("");
        }
    }

    class Program
    {
        static void ChangeCountry(Address address)
        {
            address.country = "United States of America";
            Console.WriteLine($"~~ {address.country}");
            DatabaseConstants databaseConstants = new DatabaseConstants();
            Console.WriteLine(DatabaseConstants.DB_USERNAME);
            Console.WriteLine(DatabaseConstants.DB_PASSWORD);
            Console.WriteLine(DatabaseConstants.DB_HOST);
        }

        static void Main(string[] args)
        {
            // StringValidator validator = new StringValidator();
            Console.WriteLine($"~~ IsNullOrEmpty: {StringValidator.IsNullOrEmpty("aa")} {StringValidator.DATABASE_CONNECTION_URL}");

            //Address myAddress = new Address("123 East District Ave.", "", "Paradise City", 12345, "Panama");
            //Console.WriteLine($"{myAddress.country}"); // Panama
            //ChangeCountry(myAddress);
            //Console.WriteLine($"{myAddress.country}"); // Panama
        }
    }

    interface IUpdatable
    {
        void Update();
    }

    interface IActivation
    {
        void Activate();
        void Deactivate();
    }

    // has a -> composition/aggregation
    struct Address: IUpdatable, IActivation
    {
        public string line1;
        public string line2;
        public string city;
        public int postalCode;
        public string country;

        public Address(string line1, string line2, string city, int postalCode, string country)
        {
            this.line1 = line1;
            this.line2 = line2;
            this.city = city;
            this.postalCode = postalCode;
            this.country = country;
        }

        public void Activate()
        {
            throw new NotImplementedException();
        }

        public void Deactivate()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
    
}

