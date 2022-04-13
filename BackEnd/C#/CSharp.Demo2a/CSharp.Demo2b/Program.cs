using System;

namespace CSharp.Demo2b
{

    class Bumper
    {
        public void BumpRef(ref int value)
        {
            value++;
            Console.WriteLine("~~ BumpRef: {0}", value);
        }

        public void BumpValue(int value)
        {
            value++;
            Console.WriteLine("~~ BumpValue: {0}", value);
        }
    }

    class Calculator
    {
        public void Add(int num1, int num2)
        {
            int sum = num1 + num2;
            Console.WriteLine("{0} + {1} = {2}", num1, num2, sum);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;

            Bumper bumperValue = new Bumper();
            Console.WriteLine("~~ Before: {0}", x);
            bumperValue.BumpValue(x);
            Console.WriteLine("~~ Before: {0}", x);

            //Bumper bumperRef = new Bumper();
            //Console.WriteLine("~~ Before: {0}", x);
            //bumperRef.BumpRef(ref x);
            //Console.WriteLine("~~ Before: {0}", x);

            Console.Write("Enter value for num1: ");
            int numValue1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter value for num2: ");
            int numValue2 = Convert.ToInt32(Console.ReadLine());

            Calculator calculator = new Calculator();
            calculator.Add(numValue1, numValue2);
        }
    }
}

