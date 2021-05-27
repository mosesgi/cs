using System;
using System.Collections.Generic;

using static System.Console;

namespace WorkingWithDictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            var keywords = new Dictionary<string, string>();
            keywords.Add("int", "32-bit integer data type");
            keywords.Add("long", "64-bit integer data type");
            keywords.Add("float", "Single precision floating point number");
            keywords.TryAdd("int", "another");
            WriteLine("Keywords and their definitions");
            foreach (var key in keywords.Keys)
            {
                WriteLine($" {key} : {keywords[key]}");
            }
            foreach (KeyValuePair<string, string> item in keywords)
            {
                WriteLine($" {item.Key} : {item.Value}");
            }
            WriteLine($"The definition of Long is {keywords["long"]}");
        }
    }
}
