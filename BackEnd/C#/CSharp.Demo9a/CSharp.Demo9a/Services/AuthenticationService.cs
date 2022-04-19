using System;
using CSharp.Demo9a.Models;
using CSharp.Demo9a.Helper;
using CSharp.Demo9a.Exceptions;

// Singleton

// Behavioral
// Structural
// Creational
namespace CSharp.Demo9a.Services
{
	public sealed class AuthenticationService
	{
        private static AuthenticationService INSTANCE;

        private AuthenticationService()
        {

        }

        public static AuthenticationService Instance()
        {
            if(INSTANCE == null)
            {
                INSTANCE = new AuthenticationService();
            }

            return INSTANCE;
        }


        public void authenticate(UserAccount userAccount)
        {
            if (userAccount == null)
            {
                throw new ArgumentException("User account cannot be null.");
            }

            if (StringHelper.IsNullOrEmpty(userAccount.Username))
            {
                throw new AuthenticationException("Username cannot be null or empty.");
            }

            if (StringHelper.IsNullOrEmpty(userAccount.Password))
            {
                throw new AuthenticationException("Password cannot be null or empty.");
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


}

