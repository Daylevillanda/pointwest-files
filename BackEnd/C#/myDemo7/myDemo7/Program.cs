using System;

namespace myDemo7
{
    class Geek
    {

        // Constructor without parameter
        public Geek()
        {
            Console.WriteLine("Hello! Constructor 1");
        }

        // Constructor with parameter
        // Here this keyword is used
        // to call Geek constructor
        public Geek(int a)
        : this()
        {
            Console.WriteLine("Hello! Constructor 2");
        }
        public Geek(string a)
        : this(50)
        {
            Console.WriteLine("Hello! Constructor 3");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Geek geek = new Geek("asd");

        }
    }
}
