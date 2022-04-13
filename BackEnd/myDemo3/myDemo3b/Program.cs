using System;

namespace myDemo3b
{    
    internal class Program
    {
        class Product //Properties -> Getter and Setters w/o fields
        {
            public int additionalPrice;
            //OR
            public int Id { get; set; }
            public int Price { get; private set; }//private set -> making the property read only

            public int OtherPrice
            {
                get;
                set;
            }

            public decimal TotalPrice
            {
                get { return this.Price + this.OtherPrice; }
            }        
        }
        //OR
        //Properties -> Getter and Setters with fields
        //Use this if you need to activate methods
        class Person
        {
            string name; //field            

            //OR
            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Product product = new Product();
            product.Id = 100;
            product.OtherPrice = 100;
            //or
            Product product2 = new Product
            {
                Id = 0,
                OtherPrice = 100
            };


        }
    }
}
