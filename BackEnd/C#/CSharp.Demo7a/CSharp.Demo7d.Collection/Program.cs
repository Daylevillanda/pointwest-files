using System;
using System.Collections;

// (1) non-generic collection
// (2) generic collection

// (1) ordered or unordered

// FIFO
// - Queue

// FILO
// - Stack

// (2) sorted or unsorted

// (3) duplicates or unique

// in-memory

namespace CSharp.Demo7d.Collection
{
    class Program
    {
        static void DisplayList(ArrayList arrayList)
        {
            for (int index = 0; index < arrayList.Count; index++)
            {
                Console.WriteLine($"element[{index}] = {arrayList[index]}");
            }
            Console.WriteLine("\n\n");
        }

        static void Main(string[] args)
        {
            var anyTypeList = new ArrayList();
            anyTypeList.Add("300");
            anyTypeList.Add(1);
            anyTypeList.Add("5000");
            anyTypeList.Add(100);

            int sum = 0;
            for(int index=0;index<anyTypeList.Count;index++)
            {
                var objectValue = anyTypeList[index];
                // type checking
                if(objectValue is string)
                {
                    sum += Convert.ToInt32(objectValue);
                } else
                {
                    sum += (int) objectValue;
                }
            }

            Console.WriteLine($"~~ Sum={sum}");


            // * 3 / 2 + 1
            int[] numbers = new int[30];
            Console.WriteLine(numbers.Length);

            int[] newNumbers = new int[31];

            var myList = new ArrayList(100);


            myList.Add("A");
            myList.Add("B");
            myList.Add("C");

            //foreach(string el in myList)
            //{
            //    Console.WriteLine($"Element => {el}");
            //}

            //Console.WriteLine($"~~ Array Size: {myList.Count}");

            //DisplayList(myList);

            var additionalItems = new ArrayList();
            additionalItems.Add("1");
            additionalItems.Add("2");
            additionalItems.Add("3");

            //myList.AddRange(additionalItems);
            //DisplayList(myList);

            myList.InsertRange(1, additionalItems);
            //DisplayList(myList);

            myList.RemoveRange(1, 2);
            DisplayList(myList);

            myList.Insert(0, "X");
            DisplayList(myList);
        }
    }
}

