using System;

namespace CSharp.Demo6a
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{FirstName},{LastName},{Age}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[3];

            Person person1 = new Person()
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 21
            };
            people[0] = person1;

            Person person2 = new Person()
            {
                FirstName = "John1",
                LastName = "Doe1",
                Age = 22
            };
            people[1] = person2;

            Person person3 = new Person()
            {
                FirstName = "John2",
                LastName = "Doe2",
                Age = 23
            };
            people[2] = person3;

            foreach(var p in people)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}

