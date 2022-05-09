using System;
using System.Collections;
using System.Linq;
using Microsoft.Extensions.Configuration;
using test.Data;
using test.Models;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationHelper configurationHelper = ConfigurationHelper.Instance();
            var dbString = configurationHelper.GetProperty<string>("ConnectionString");
            Console.WriteLine(dbString);
            using(db db = new db(dbString))
            {
                Employee emp = db.Employees.Find(1);
                Console.WriteLine(emp.FirstName);
            }
        }
    }
}
