using System;

namespace CSharp.Demo2d
{
    class Point
    {
        // instance variables
        public int x;
        public int y;

        public void DisplayLocation()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // NULLIF
            int? deliveryFee = null;
            int minimumDeliveryFee = 50;

            int productPrice = 100;
            int orderQuantity = 2;
            // int totalAmount = (productPrice * orderQuantity) + (deliveryFee ?? minimumDeliveryFee);
            int totalAmount = (productPrice * orderQuantity) + (deliveryFee.GetValueOrDefault());
            Console.WriteLine("~~ Total Amount: {0}", totalAmount);


            // method/local variables
            Nullable<int> a = null;
            Console.WriteLine($"~~ a={a.GetValueOrDefault()}");

            int? x = null;
            int? y = null;
            Console.WriteLine($"~~ x={x.GetValueOrDefault()}, y={y.GetValueOrDefault()}");

            Point pointA = new Point();
            Console.WriteLine($"~~ x={pointA.x}, y={pointA.y}");
           
            int num1 = 10;
            Int32 num2 = 10;
            int num3 = num2;
            Int32 num4 = num3;

            // nullable
            int? myNumber = null;

            // Boxing/Unboxing
            Console.WriteLine("Hello World!");
        }
    }
}

