using System;

namespace CSharp.Demo2c
{
    // is a, has a

    // What?

    class ShoppingCart
    {

    }

    class Product
    {

    }

    class Customer
    {

    }

    class Order
    {

    }

    class OrderFulfillment
    {

    }

    class Merchant
    {

    }

    class Voucher
    {

    }

    class Review
    {

    }

    class CustomerAccount
    {

    }

    class MerchantAccount
    {

    }

    class WishList
    {

    }

    class ProductCatalog
    {

    }

    class ProductCategory
    {

    }

    class Payment
    {

    }

    class DeliveryMethod
    {

    }


    class PaymentProcessor
    {
        public void ProcessPayment()
        {

        }
    }

    class CreditCardPaymentProcessor
    {

    }

    class PaypalPaymentProcessor
    {

    }

    class CryptoPaymentProcessor
    {

    }

    class Bulb
    {
        bool on;

        public void TurnOn()
        {
            if (on)
            {
                Console.WriteLine("~~ Bulb is already on!");
            }
            else
            {
                on = true;
                Console.WriteLine("~~ Bulb turned on...");
            }
            
        }

        public void TurnOff()
        {
            if(on)
            {
                on = false;
                Console.WriteLine("~~ Bulb turned off...");
            }
            else
            {
                Console.WriteLine("~~ Bulb is off!");
            }
           
        }

        public string GetStatus()
        {
            return on ? "ON" : "OFF";
        }
    }

    class Calculator
    {
        public int Add(int num1, int num2)
        {
            // int sum = num1 + num2;
            // return sum;

            return num1 + num2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Bulb bulb = new Bulb();
            bulb.TurnOff();
            bulb.TurnOn();
            Console.WriteLine("~~ Bulb Status: {0}", bulb.GetStatus());
            bulb.TurnOn();
            bulb.TurnOff();
            Console.WriteLine("~~ Bulb Status: {0}", bulb.GetStatus());

            Calculator calculator = new Calculator();

            Console.Write("Enter value for num1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter value for num2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int sum = calculator.Add(num1, num2);
            Console.WriteLine($"Sum: {sum}");
        }
    }
}

