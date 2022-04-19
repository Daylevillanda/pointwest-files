using System;

namespace myDemo8
{
    class UserAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    class AuthenticationService
    {
        public static bool Authenticate(UserAccount userAccount)
        {
            if(userAccount == null)
            {
                throw new ArgumentNullException("User cannot be null");
            }
            if(userAccount.Username == null || "".Equals(userAccount.Username.Trim()))
            {
                return false;
            }

            return true;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
