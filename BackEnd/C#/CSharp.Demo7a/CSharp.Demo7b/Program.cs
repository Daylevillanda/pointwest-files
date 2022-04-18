using System;

namespace CSharp.Demo7b
{
    class A
    {
        public A()
        {
            Console.WriteLine("~~ A()");
        }

        public A(string message)
        {
            Console.WriteLine($"~~ A({message})");
        }
    }

    class B: A
    {
        public B(): base("Message from B class")
        {
            Console.WriteLine("~~ B()");
        }
    }

    class C: B
    {
        public C()
        {
            Console.WriteLine("~~ C()");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            C c = new C();
        }
    }
}

