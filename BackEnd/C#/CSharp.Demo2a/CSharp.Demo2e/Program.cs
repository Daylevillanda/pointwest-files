using System;

namespace CSharp.Demo2e
{
    class ParameterArray
    {
        public void Add(int[] numbers)
        {
            int sum = 0;
            foreach(int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"~~ Sum: {sum}");
            
        }

        public void AddAsParamArray(params int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"~~ Sum: {sum}");

        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            ParameterArray parameterArray = new ParameterArray();
            parameterArray.Add(new int[] { 1, 2, 3, 4, 5 ,6});
            parameterArray.AddAsParamArray(1, 2, 3, 4, 5, 6);

            int[] prices = { 100, 9, 8, 7, 6, 5, 4, 3, 2, 99};
            //Array.Reverse(prices);
            Array.Sort(prices);
            foreach(int price in prices)
            {
                Console.WriteLine($"Price -> {price}");
            }

            // Arrays 
            // Fixed Type
            // Fixed Size
            // Sequential - Ordered, Sorted
            // Ordered or Unordered
            // Sorted or Unsorted

            double[] payments = new double[10];

            string[] firstQuarterMonthNames = new string[3];
            firstQuarterMonthNames[0] = "January";
            firstQuarterMonthNames[1] = "February";
            firstQuarterMonthNames[2] = "March";

            for (int index=0;index<firstQuarterMonthNames.Length;index++)
            {
                Console.WriteLine($"First Quarter Index {index}: {firstQuarterMonthNames[index]}");
            }

            foreach(string monthName in firstQuarterMonthNames)
            {
                Console.WriteLine($"\n{monthName}");
            }

            string[] secondQuarterMonthNames = new string[]
            {
                "April",
                "May",
                "Jun"
            };
            string[] dayNames = new string[]
            {
                "Monday",
                "Tuesday",
                "Wednesday"
            };


            int[,] numbers = new int[3, 3]
            {
                {1, 2, 3}, // 0
                {4, 5, 6}, // 1
                {7, 8, 9}  // 2
            };

            //Console.WriteLine($"{numbers[1, 2]}"); //
            //Console.WriteLine($"{numbers[0, 1]}"); //

            for(int i = 0; i < 3; i++)
            {
                for(int j=0;j<3;j++)
                {
                    Console.Write($"{numbers[i, j]}");
                }
                Console.WriteLine("\n");
            }

        }
    }
}

