using System;

namespace myDemo3
{
    //constructor
    class MobileWallet
    {
        decimal balance;
        decimal otherBalance;
        public MobileWallet(decimal otherBalance)
        {
            this.balance = 10_000M;
            this.otherBalance = otherBalance;
        }

        public void Credit(decimal amount)
        {

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MobileWallet wallet = new MobileWallet(1_000M);
            Console.WriteLine(wallet);
        }
    }
}
