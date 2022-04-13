using System;

namespace myDemo2c
{
    class Calculator
    {
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Console.WriteLine(calculator.Add(4,4));
        }
    }
}
