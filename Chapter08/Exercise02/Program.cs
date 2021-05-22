using System;
using System.Text.RegularExpressions;
using static System.Console;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string regPattern = @"\d+";
                Write("Enter a regular expression (or press ENTER to use the default): ");
                string pattern = ReadLine();
                Write("Enter some input: ");
                string input = ReadLine();
                if (string.IsNullOrEmpty(pattern))
                {
                    pattern = regPattern;
                }
                Regex reg = new Regex(pattern);
                WriteLine($"{input} matches {pattern}? {reg.IsMatch(input)}");
                WriteLine("Press ESC to end or any key to try again.");
                ConsoleKeyInfo key = ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    return;
                }
            }
        }
    }
}
