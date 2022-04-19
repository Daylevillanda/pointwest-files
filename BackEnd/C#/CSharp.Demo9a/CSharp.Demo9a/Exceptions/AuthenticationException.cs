using System;
namespace CSharp.Demo9a.Exceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException() : this("Authentication Failure")
        {

        }

        public AuthenticationException(string message) : base(message)
        {

        }
    }
}

