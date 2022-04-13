using System;

namespace myDemo2b
{
    class Calculator
    {
        public void Add(int num1, int num2)
        {
            int sum = num1 + num2;
            Console.WriteLine("{0} + {1} = {2}", num1, num2, sum);

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter num1: ");
            int numValue1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter num2: ");
            int numValue2 = Convert.ToInt32(Console.ReadLine());

            Calculator calculator = new Calculator();
            calculator.Add(numValue1, numValue2);

        }
    }
}
