using System;


namespace CSharp.Demo5d.Services.Windows
{
    internal class FileWriter
    {
        public void WriteToFile(string fileContent)
        {
            Console.WriteLine($"{fileContent} written to a windows file.");
        }
    }

}

namespace CSharp.Demo5d.Services.Linux
{

    internal class FileWriter
    {
        public void WriteToFile(string fileContent)
        {
            Console.WriteLine($"{fileContent} written to a linux file.");
        }
    }

}


