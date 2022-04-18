using System;
using System.Collections.Generic;

namespace CSharp.LabExercise6
{
    class Validations
    {
        public static bool HasWhitespace(string text)
        {
            foreach (char ch in text)
            {
                if (Char.IsWhiteSpace(ch))
                {
                    Console.WriteLine("Please Remove Whitespaces");
                    return false;
                }
            }
            return true;
        }
        public static bool IsValidLetter(string text)
        {
            string validLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            foreach (char ch in text.ToUpper())
            {
                if (!validLetters.Contains(ch))
                {
                    Console.WriteLine("Please Input A Valid Word");
                    return false;
                }
            }
            return true;
        }
    }
    class Letters
    {
        public Dictionary<int, string> letterWithValue { get; set; }
        public Letters()
        {
            letterWithValue = new Dictionary<int, string>()
            {
                {1, "AEIOULNRST" },
                {2, "DG" },
                {3, "BCMP" },
                {4, "FHVWY" },
                {5, "K" },
                {8, "JX" },
                {10, "QZ" }
            };
        }
    }

    class Scrabble
    {
        Letters letters;
        public Scrabble()
        {
            this.letters = new Letters();
        }

        public void Start()
        {
            var answer = "y";
            while (answer.Trim().ToLower().Equals("y"))
            {
                Console.Write("Enter A Word: ");
                string inputWord = Console.ReadLine();
                int points = 0;

                if (Validations.HasWhitespace(inputWord) && Validations.IsValidLetter(inputWord))
                {
                    foreach (char ch in inputWord.ToUpper())
                    {
                        foreach (KeyValuePair<int, string> pair in this.letters.letterWithValue)
                        {
                            if (pair.Value.Contains(ch))
                            {
                                points += pair.Key;
                            }
                        }
                    }
                    Console.WriteLine($"\"{inputWord}\" word is worth {points} points");
                }

                Console.Write("Do you want to continue(y/n)? ");
                answer = Console.ReadLine().ToLower();

            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Scrabble scrabble = new Scrabble();
            scrabble.Start();
        }
    }
}
