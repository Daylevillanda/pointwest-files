using System;

namespace DataAccess
{

    public class BaseClass
    {
        protected internal string GetSomeInformation()
        {
            return "Some useful information.";
        }

        public void Display()
        {
            GetSomeInformation();
        }
    }

    public class ChildClass: BaseClass
    {
        public void SomeTest()
        {
            GetSomeInformation();
        }
    }

    public class ExternalClass
    {
        public string label;
        public string value;

        private void SayHello()
        {
            Console.WriteLine("Hello World!");
        }
    }

    class InternalClass
    {
        public void Test()
        {
            ChildClass childClass = new ChildClass();
           ; childClass.GetSomeInformation()
        }
    }
}

