using System;

namespace CSharp.Demo1a
{
    class Program
    {
        static void Demo1()
        {
            // comparision operators
            // ==, !=, >, >=, <, <=, !
            int managerAge = 60;
            int staffAge = 28;
            bool isManagerOlderThanStaff = managerAge >= staffAge;

            // logical operators && ||
            bool isAvailable = true;
            bool isExpensive = false;
            bool acceptOffer = isAvailable && isExpensive;
            // Logical OR ||
            // TT = T
            // TF = T
            // FF = F

            // Logical AND &&
            // TT = T
            // TF = F
            // FF = F

            // compound operator
            int counter = 100;
            counter = counter + 2; // 102
            counter += 2;
            counter *= 2; // counter = counter * 2;

            // ++ and --
            // prefix or postfix
            // ++x
            // x++
            int x = 10;
            int y = x++;
            Console.WriteLine(x); // x=? 11
            Console.WriteLine(y); // y=? 10

            int a = 10;
            int b = ++a;
            Console.WriteLine(a); // a=? 11
            Console.WriteLine(b); // b=? 11

            int num1 = 5;
            int num2 = 3;
            int num3 = 4;
            int result = (++num1) + (--num2) + (num3++);
            Console.WriteLine("result={0}, num1={1}, num2={2}, num3={3}", result, num1, num2, num3);
            // 8, 6, 2, 5
            // 12, 6, 2,4
            // 12, 6, 2, 5
            // 13, 6, 2, 5


            Console.Write("Enter value for number 1: ");
            int number1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter value for number 2: ");
            int number2 = Convert.ToInt32(Console.ReadLine());

            int sum = number1 + number2;
            Console.WriteLine("{0} + {1} = {2}", number1, number2, sum);

            int difference = number1 - number2;
            Console.WriteLine("{0} - {1} = {2}", number1, number2, difference);

            int product = number1 * number2;
            Console.WriteLine("{0} * {1} = {2}", number1, number2, product);

            decimal quotient = number1 / number2;
            Console.WriteLine("{0} / {1} = {2}", number1, number2, quotient);

            int remainder = number1 % number2;
            Console.WriteLine("{0} + {1} = {2}", number1, number2, remainder);

            float productPrice = 99.95F;
            int someRandomProductPrice = (int)productPrice;
            Console.WriteLine("~~ productPrice: {0}, someRandomProductPrice: {1}", productPrice, someRandomProductPrice);

            int savingsAccountDepositAmount = 100_000_000;
            Console.WriteLine("~~ savingsAccountDepositAmount: {0}", savingsAccountDepositAmount);

            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Hello {0} {1}!", firstName, lastName);
        }

        static void Demo2()
        {
            // Demo1a();

            // Ternary ?:
            int colorCode = 1;
            string colorName = "";
            if (colorCode == 1)
            {
                colorName = "Blue";
            }
            else
            {
                colorName = "Red";
            }

            colorName = colorCode == 1 ? "Blue" : "Red";
            Console.WriteLine("~~ Color Name: {0}", colorName);

            Console.WriteLine("[1] Balance Inquiry");
            Console.WriteLine("[2] Deposit");
            Console.WriteLine("[3] Withdraw");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (Convert.ToInt32(choice))
            {
                case 1:
                    Console.WriteLine("~~ Balance Inquiry");
                    break;
                case 2:
                    Console.WriteLine("~~ Deposit");
                    break;
                case 3:
                    Console.WriteLine("~~ Withdraw");
                    break;
                default:
                    Console.WriteLine("~~ Invalid choice!");
                    break;
            }


            if (choice == "1")
            {
                Console.WriteLine("~~ balance inquiry");
            }
            else if (choice == "2")
            {
                Console.WriteLine("~~ deposit");
                Console.Write("Enter amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                if (amount < 1000)
                {
                    Console.WriteLine("Minimum deposit amount is PHP 1000");
                }
                else
                {
                    Console.WriteLine("Deposit transaction successful: PHP {0}", amount);
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("~~ withdraw");
            }
            else
            {
                Console.WriteLine("~~ invalid choice");
            }

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine(); ;

            if (username == "admin" && password == "password")
            {
                Console.WriteLine("Welcome, super user!");
            }
            else
            {
                Console.WriteLine("Welcome, guest!");
            }
        }
    

        static void Main(string[] args)
        {
            // for
            for(int i=0;i<10;i++)
            {
                Console.WriteLine("~~ i={0}", i);
            }

            int counter = 0;
            while(counter <= 100)
            {
                if(counter == 50)
                {
                    break;
                }

                if(counter % 2 != 0)
                {
                    counter++;
                    continue;
                }

                Console.WriteLine("~~ counter={0}", counter);
                counter++;
            }

            int age = 20;
            do
            {
                Console.WriteLine(age);
                age++;
            } while (age <= 18);

            while(true)
            {
                Console.WriteLine("[1] Balance Inquiry");
                Console.WriteLine("[2] Deposit");
                Console.WriteLine("[3] Withdraw");
                Console.WriteLine("[4] Exit");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                switch (Convert.ToInt32(choice))
                {
                    case 1:
                        Console.WriteLine("~~ Balance Inquiry");
                        break;
                    case 2:
                        Console.WriteLine("~~ Deposit");
                        break;
                    case 3:
                        Console.WriteLine("~~ Withdraw");
                        break;
                    case 4:
                        Console.WriteLine("~~ Exit");
                        Environment.Exit(-1);
                        break;
                    default:
                        Console.WriteLine("~~ Invalid choice!");
                        break;
                }
            }
        }
    }
}

