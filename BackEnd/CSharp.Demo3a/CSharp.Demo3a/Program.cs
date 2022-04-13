using System;

namespace CSharp.Demo3a
{
    // Constructor
    //  - is a special method that is invoked every time you create an instance of the class
    //  - initialize object state
    //  - invoked once
    class MobileWallet
    {
        int walletId;
        string customerName;
        decimal balance;

        public MobileWallet(int walletId, string customerName, decimal balance)
        {
            if(walletId < 1)
            {
                throw new ArgumentException("Invalid Wallet ID.");
            }

            if(customerName == null || customerName.Trim().Length == 0) 
            {
                throw new ArgumentException("Invalid Customer Name.");
            }

            if(balance < 1)
            {
                throw new ArgumentException("Invalid Wallet Balance.");
            }

            this.walletId = walletId;
            this.customerName = customerName;
            this.balance = balance;
        }

        public void Credit(decimal amount)
        {
            // local validation
            if(amount > 0)
            {
                this.balance += amount;
            }
        }

        public void Debit(decimal amount)
        {
            if(amount % 100 != 0)
            {
                throw new ArgumentException("Amount must be divisible by 100.");
            }

            if(amount < 1)
            {
                throw new ArgumentException("Invalid amount. Amount should be a positive integer value.");
            }

            if(amount > balance)
            {
                throw new ArgumentException("Insufficient balance.");
            }

            this.balance -= amount;
        }

        public decimal GetBalance()
        {
            return this.balance;
        }

        public void PrintBalance()
        {
            Console.WriteLine("~~ Wallet Balance: {0}", balance);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Wallet ID: ");
            int walletId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter Wallet Balance: ");
            decimal walletBalance = Convert.ToDecimal(Console.ReadLine());

            MobileWallet mobileWallet = new MobileWallet(walletId, customerName, walletBalance);
            mobileWallet.PrintBalance();
            mobileWallet.Credit(1_000M);
            mobileWallet.PrintBalance();
            mobileWallet.Debit(100);
            mobileWallet.PrintBalance();
        }
    }
}

