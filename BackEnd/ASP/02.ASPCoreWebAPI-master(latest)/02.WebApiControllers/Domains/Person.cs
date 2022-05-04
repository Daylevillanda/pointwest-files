using Bogus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Domain
{
    public class Person
    {
        public Person() : this("", "", 0)
        {
        }

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class PersonTestData
    {

        private static List<Person> personList;

        public static List<Person> GetPersonList()
        {
            if (personList is object)
            {
                return personList;
            }

            personList = new List<Person>();
            foreach (int index in Enumerable.Range(1, 100))
            {
                var personFaker = new Faker<Person>()
                     .RuleFor(o => o.Id, f => index)
                     .RuleFor(o => o.FirstName, f => f.Person.FirstName)
                     .RuleFor(o => o.LastName, f => f.Person.LastName)
                     .RuleFor(o => o.Email, f => f.Person.Email)
                     .RuleFor(o => o.Password, f => f.Random.AlphaNumeric(10))
                     .RuleFor(o => o.Age, f => f.Random.Number(18, 65));

                personList.Add(personFaker);
            }

            return personList;
        }
    }
}
