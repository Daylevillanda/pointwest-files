using System;

namespace CSharp.LabExercise3
{
    class Account
    {
        public decimal Balance { get; set; }

        public Account()
        {
            this.Balance = 0;
        }
    }

    class BalanceRenderer
    {
        Account account;
        public BalanceRenderer(Account account)
        {
            this.account = account;
        }

        public decimal DisplayBalance()
        { return this.account.Balance; }
    }

    class Withdraw
    {
        Account account;

        public Withdraw(Account account)
        {
            this.account = account;
        }

        public void WithdrawBalance(decimal amount)
        {              
            this.account.Balance -= amount;
            Console.WriteLine("\nWithdraw Transaction Successful");
        }
    }

    class Deposit
    {
        Account account;

        public Deposit(Account account)
        {
            this.account = account;
        }

        public void DepositBalance(decimal amount)
        {
            this.account.Balance += amount;
            Console.WriteLine("\nDeposit Transaction Successful");
        }
    }

    class StartTransaction
    {
        Account account;
        BalanceRenderer balanceRenderer;
        Withdraw withdraw;
        Deposit deposit;

        public StartTransaction()
        {
            this.account = new Account();
            this.balanceRenderer = new BalanceRenderer(account);
            this.withdraw = new Withdraw(account);
            this.deposit = new Deposit(account);
        }

        public decimal GetBalance()
        {
            return this.account.Balance;            
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"\nYOUR BALANCE IS {this.balanceRenderer.DisplayBalance()}\n");
        }

        public void WithdrawBalance(decimal amount)
        {
            this.withdraw.WithdrawBalance(amount);
            this.DisplayBalance();
        }

        public void DepositBalance(decimal amount)
        {
            this.deposit.DepositBalance(amount);
            this.DisplayBalance();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StartTransaction transaction = new StartTransaction();
            bool start = true;

            do
            {
                Console.WriteLine("*********Welcome To ATM Service*********\n");
                Console.WriteLine("1. Check Balance\n");
                Console.WriteLine("2. Withdraw Cash\n");
                Console.WriteLine("3. Deposit Cash\n");
                Console.WriteLine("4. Quit\n");
                Console.WriteLine("****************************************");
                Console.Write("Enter Your Choice: ");
                int action = Convert.ToInt32(Console.ReadLine());

                switch(action)
                {
                    case 1: transaction.DisplayBalance(); break;

                    case 2:
                        {
                            Console.Write("\nEnter The Amount To Withdraw: ");
                            int amount = Convert.ToInt32(Console.ReadLine());
                            if (amount <= -1)
                            {
                                Console.WriteLine("\nAmount Should Not be A Negative Value\n");
                                break;
                            }

                            if (transaction.GetBalance() < amount)
                            {
                                Console.WriteLine("\nInsufficient Funds\n");
                                break;
                            }

                            transaction.WithdrawBalance(amount);
                            break;
                        }

                    case 3:
                        {
                            Console.Write("\nEnter The Amount To Deposit: ");
                            int amount = Convert.ToInt32(Console.ReadLine());
                            if (amount <= 0)
                            {
                                Console.WriteLine("\nAmount Should Be Greater Than 0\n");
                                break;
                            }

                            transaction.DepositBalance(amount);
                            break;
                        }

                    case 4: Console.WriteLine("\nThank You!"); start = false; break;
                }

            }while (start);
        }
    }
}
