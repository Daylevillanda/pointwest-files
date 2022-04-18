using System;
using System.Collections.Generic;

namespace CSharp.Demo7g.Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> songs = new Dictionary<string, string>();
            songs.Add("A", "ABC");
            songs.Add("B", "ABC");
            songs.Add("C", "ABC");
            songs.Add("D", "ABC");
            string mySong = "";
            if (songs.TryGetValue("A", out mySong))
            {
                Console.WriteLine($"Song found {mySong}");
            }

            Dictionary<string, string>.KeyCollection keys = songs.Keys;
            foreach (var key in keys)
            {
                Console.WriteLine($"Key = {key}");
            }

            Dictionary<string, string>.ValueCollection values = songs.Values;
            foreach (var value in values)
            {
                Console.WriteLine($"Value = {value}");
            }

            foreach (KeyValuePair<string, string> pair in songs)
            {
                Console.WriteLine($"Key = {pair.Key}, Value = {pair.Value}");
            }

        }
    }
}
