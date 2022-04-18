using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.Demo7f.Collection
{
    class Student: IEquatable<Student>
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GradeLevel { get; set; }

        public bool Equals(Student other)
        {
            if(other == null)
            {
                throw new ArgumentException("Student object cannot be null");
            }

            return this.ID == other.ID;
        }

        public override string ToString()
        {
            return $"{ID}, {FirstName}, {LastName}, {GradeLevel}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Student> students = new HashSet<Student>();

            var student1 = new Student
            {
                ID = 1,
                FirstName = "John",
                LastName = "Doe",
                GradeLevel = 7
            };
            Console.WriteLine($"~~ Add student: {students.Add(student1)}");

            var student2 = new Student
            {
                ID = 2,
                FirstName = "John",
                LastName = "Doe",
                GradeLevel = 7
            };
            Console.WriteLine($"~~ Add student: {students.Add(student2)}");

            var student3 = new Student
            {
                ID = 1,
                FirstName = "Will",
                LastName = "Smith",
                GradeLevel = 8
            };
            Console.WriteLine($"~~ Add student: {students.Add(student3)}");
            Console.WriteLine($"~~ Student Count: {students.Count}");


            HashSet<string> uniqueMessages = new HashSet<string>();
            Console.WriteLine(uniqueMessages.Add("A"));
            Console.WriteLine(uniqueMessages.Add("B"));
            Console.WriteLine(uniqueMessages.Add("C"));
            Console.WriteLine(uniqueMessages.Add("A"));
            Console.WriteLine(uniqueMessages.Add("B"));
            Console.WriteLine(uniqueMessages.Add("C"));
            
            Console.WriteLine($"~~ Number of messages: {uniqueMessages.Count}");
            foreach(var uniqueMessage in uniqueMessages)
            {
                Console.WriteLine($"~~ Message: {uniqueMessage}");
            }

        }
    }
}

