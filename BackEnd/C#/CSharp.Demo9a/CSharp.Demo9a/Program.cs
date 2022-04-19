using System;
using CSharp.Demo9a.Exceptions;
using CSharp.Demo9a.Models;
using CSharp.Demo9a.Helper;
using CSharp.Demo9a.Services;


namespace CSharp.Demo9a
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AuthenticationService authenticationService1 = AuthenticationService.Instance();
            AuthenticationService authenticationService2 = AuthenticationService.Instance();
            Console.WriteLine(authenticationService1 == authenticationService2);

        }
    }
}

