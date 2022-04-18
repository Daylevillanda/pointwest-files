using System;
using System.Collections;

namespace myDemo7d
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void DisplayItems (ICollection collection)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine(item);
                }
            }
            //var myList = new ArrayList();

            //myList.Add("A");
            //myList.Add("B");
            //myList.Add("C");

            //myList.Insert(1, 1);

            //int[] myArray = { 1, 2, 3 };

            //myList.InsertRange(0, myArray);

            //var myList = new ArrayList(5);
            //Console.WriteLine(myList.Count);
            
            ArrayList anotherList = new ArrayList();
            anotherList.Add("1");
            anotherList.Add(2);
            foreach (var item in anotherList)
            {
                Console.WriteLine(Convert.ToInt32(item));
            }
        }
    }
}
