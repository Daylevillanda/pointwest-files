using System;

namespace CSharp.Demo5a
{
    class Program
    {
        enum Month
        {
            January = 1,    // 0
            February,   // 1
            March,      // 2
            April,      // 3
            May = 100,  // 4
            June,       // 5
            July,       // 6
            Auguest,    // 7
            September,  // 8
            October,    // 9
            November,   // 10
            December    // 11
        }

        enum Day
        {
            ONE,
            TWO,
            THREE,
            FOUR,
            FIVE,
            SIX,
            SEVEN,
            EIGHT,
            NINE,
            TEN
        }

        enum Level
        {
            LOW,
            MEDIUM,
            HIGH,
            SUPER
        }

        class ElectricFan
        {
            public void ChangeMode(Level level)
            {
                switch(level)
                {
                    case Level.LOW:
                        Console.WriteLine("Running fan in low mode.");
                        break;
                    case Level.MEDIUM:
                        Console.WriteLine("Running fan in medium mode.");
                        break;
                    case Level.HIGH:
                        Console.WriteLine("Running fan in high mode");
                        break;
                }
            }
        }

        // enum makes your variables type safety 
        static void ScheduleMedicalAppointment(Month preferredMonth, Day preferredDay)
        {
            //if(!(day >= 1 && day <= 31))
            //{
            //    throw new ArgumentException("Invalid day. Day should be a number between 1-31.");
            //}
        }

        static void ScheduleMedicalAppointment(string monthName, int day)
        {


            if (!(day >= 1 && day <= 31))
            {
                throw new ArgumentException("Invalid day. Day should be a number between 1-31.");
            }
        }

        static void Main(string[] args)
        {
            int monthAsAnInteger1 = (int)Month.January; // January = 1
            Console.WriteLine($"Month as integer value: {monthAsAnInteger1}");

            int monthAsAnInteger2 = (int)Month.June;
            Console.WriteLine($"Month as integer value: {monthAsAnInteger2}");

            int monthAsAnInteger3 = (int)Month.December;
            Console.WriteLine($"Month as integer value: {monthAsAnInteger3}");

            ElectricFan smartFan = new ElectricFan();
            smartFan.ChangeMode(Level.MEDIUM);

            ScheduleMedicalAppointment(Month.April, Day.TEN);
        }
    }
}

