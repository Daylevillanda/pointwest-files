using System;
using System.IO;
using System.Collections.Generic;

namespace CSharp.Demo11a
{
    class Employee
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{ID},{FirstName},{LastName},{Salary}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // FileExists();
            // ReadFile();
            // WriteToFile();

            Employee someEmployee = new Employee
            {
                ID = "1000",
                FirstName = "Ted",
                LastName = "Beavis",
                Salary = 15000
            };
            WriteToFile(someEmployee);
        }

        static void WriteToFile()
        {
            string filePath = "/tmp/employeedb.dat";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Chris7,Co1");
                writer.WriteLine("Chris8,Co2");
                writer.WriteLine("Chris9,Co3");
            }
        }

        static void WriteToFile(Employee employee)
        {
            string filePath = "/tmp/employeedb.dat";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(employee.ToString());
            }
        }

        static void ReadFile()
        {
            string filePath = "/tmp/employee.txt";
            List<Employee> employees = new List<Employee>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                //foreach(string line in lines)
                //{
                //    Console.WriteLine($"Line: {line}");
                //}

                for(int lineNumber=0;lineNumber < lines.Length;lineNumber++)
                {
                    string[] columns = lines[lineNumber].Split(",");
                    var employee = new Employee
                    {
                        ID = columns[0],
                        FirstName = columns[1],
                        LastName = columns[2],
                        Salary = Convert.ToDecimal(columns[3])
                     };
                    employees.Add(employee);
                    // Console.WriteLine($"{lineNumber + 1}: {lines[lineNumber]}");
                    //Console.WriteLine($"{lineNumber + 1}: Employee ID={employeeId}, First Name={firstName}, Last Name={lastName}, Salary={salary}");
                }

                foreach(var employee in employees)
                {
                    Console.WriteLine(employee.ToString());
                }

                Console.WriteLine("\n---------------------------\n");
                string fileContent = File.ReadAllText(filePath);
                Console.WriteLine(fileContent);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void FileExists()
        {
            // Windows C:\Program Files\
            // string filePath = @"D:\Program Files\Documents";
            string filePath = " /tmp/employee.txt";

            if(File.Exists(filePath))
            {
                Console.WriteLine("Employee text exist.");
                File.Delete(filePath);
                Console.WriteLine("Employee text file successfully deleted.");
            }
            else
            {
                Console.WriteLine("Employee text file doesn't exist");
                File.Create(filePath);
                Console.WriteLine("Employee text file successfully created.");
            }

        }
    }
}

