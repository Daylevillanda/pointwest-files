using System;

namespace CSharp.Demo5b
{
    enum SwitchMode
    {
        ON,  // 0
        OFF // 1
    }

    class Program
    {
        static void Main(string[] args)
        {
            // string input = Console.ReadLine();
            // SwitchMode mode = (SwitchMode)Enum.Parse(typeof(SwitchMode), input);
            // SwitchMode mode = (SwitchMode)Enum.Parse(typeof(SwitchMode), input, true);
            // Console.WriteLine("Mode: {0}", mode);


            //int input = Convert.ToInt32(Console.ReadLine());
            //var mode = (SwitchMode)input;
            //Console.WriteLine("Mode: {0}", mode);

            foreach(SwitchMode myMode in Enum.GetValues(typeof(SwitchMode)))
            {
                Console.WriteLine($"{myMode}");
            }
        }
    }
}

