using System;

namespace CSharp.Demo8a
{
    // Model
    class UserAccount
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    class AuthenticationException: Exception
    {
        public AuthenticationException(): this("Invalid credentials. Authentication failed.")
        {

        }

        public AuthenticationException(string message): base(message)
        {

        }
    }

    // Business - Service
    class AuthenticationService
    {
        public void Authenticate(UserAccount userAccount)
        {
            if(userAccount == null)
            {
                throw new ArgumentException("User account cannot be null.");
            }

            if(userAccount.Username == null || "".Equals(userAccount.Username.Trim()))
            {
                throw new AuthenticationException("Username cannot be null or empty");
            }

            if (userAccount.Password == null || "".Equals(userAccount.Password.Trim()))
            {
                throw new AuthenticationException("Password cannot be null or empty");
            }

            if(userAccount.Username.Trim().Length < 3)
            {
                throw new AuthenticationException("Username should have a minimum of 3 characters.");
            }

            if (!userAccount.Username.Equals("admin"))
            {
                throw new AuthenticationException("Invalid username");
            }

            if (!userAccount.Password.Equals("pass123"))
            {
                throw new AuthenticationException("Invalid password");
            }
        }
    }

    class UserAccountRepository
    {

    }

    // Exception

    class StringHelper
    {
        public static void IsEmptyOrNull(string value)
        {
            if(value == null || value.Trim().Equals(""))
            {
                //throw new ArgumentException("String value cannot be null or empty");
                throw new Exception("Some message");
            }
        }
    }
    
    class Program
    {
        static void TryAndCatch()
        {
            try
            {
                int[] numbers = { 1, 2, 3 };
                Console.WriteLine(numbers[3]);
                Console.WriteLine("success...");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Element doesn't exist" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknowne error: " + e.Message);
                Console.WriteLine(e.GetType());
            }

        }

        static void MultipleCatch()
        {
            int a, b, c;
            Console.WriteLine("Enter number values");

            try
            {
                a = Convert.ToInt32(Console.ReadLine());
                b = Convert.ToInt32(Console.ReadLine());
                c = a / b;
                Console.WriteLine($"c={c}");
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine($"Second number should not be zero: {e.Message}");
            }
            catch(FormatException e)
            {
                Console.WriteLine($"Invalid input. Value should be a number: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Generic Error: {e.Message}");
            }
            finally
            {
                Console.WriteLine("Finally block executed.");
            }
        }

        static void Main(string[] args)
        {
            //TryAndCatch();
            //MultipleCatch();

            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            UserAccount userAccount = new UserAccount
            {
                Username = username,
                Password = password
            };

            AuthenticationService authenticationService = new AuthenticationService();
            try
            {
                authenticationService.Authenticate(userAccount);
                Console.WriteLine("Login successful.");
            }
            catch(AuthenticationException e)
            {
                Console.WriteLine(e.Message);
            }
            
            
        }
    }
}

