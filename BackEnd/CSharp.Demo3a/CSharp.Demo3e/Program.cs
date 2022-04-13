using System;

namespace CSharp.Demo3e
{
    // Inheritance - Code Reuse
    // Parent -> Child
    // Super -> Subclass
    // Base -> Derived
    // "IS A" relationship

    sealed class Logger
    {

    }

    //class SimpleLogger: Logger
    //{

    //}

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public virtual void Display()
        {
            Console.WriteLine($"{FirstName}, {LastName}, {Age}");
        }
    }

    class Student: Person
    {
        public long StudentID { get; set; }
        public int GradeLevel { get; set; }

        public override void Display()
        {
            Console.WriteLine($"{StudentID}");
            base.Display();
            Console.WriteLine($"{GradeLevel}");
        }
    }

    class Employee: Person
    {
        public long EmployeeID { get; set; }
        public decimal Salary { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Person();

            Person student = new Student
            {
                StudentID = 202204080001,
                FirstName = "John",
                LastName = "Doe",
                Age = 18,
                GradeLevel = 12
            };
            student.Display();

            //Employee employee = new Employee
            //{
            //    EmployeeID = 1000,
            //    FirstName = "Donald",
            //    LastName = "Lacson",
            //    Age = 55,
            //    Salary = 350_000M
            //};
            //employee.Display();
        }
    }
}

