using System;
using System.IO;
using System.Collections;
using System.Linq;
using CSharp.Demo5d.Services.Linux;
using CSharp.Demo5d.Services.Windows;
using DataAccess;

namespace CSharp.Demo5d
{
    class ExternalChildClass: BaseClass
    {
        public void SomeUsefulLogic()
        {
            GetSomeInformation();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            ChildClass childClass = new ChildClass();
            childClass.SomeTest();
            //childClass.GetSomeInformation();

            ExternalClass ec = new ExternalClass();
            // InternalClass ic = new InternalClass();

            CSharp.Demo5d.Services.Windows.FileWriter windowsFileWriter = new CSharp.Demo5d.Services.Windows.FileWriter();
            windowsFileWriter.WriteToFile("Welcome to C#");

            CSharp.Demo5d.Services.Linux.FileWriter linuxFileWriter = new CSharp.Demo5d.Services.Linux.FileWriter();
            linuxFileWriter.WriteToFile("Welcome to C#");
        }
    }
}