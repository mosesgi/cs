using System;

using static System.Console;

namespace WorkingWithRanges
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Samantha Jones";
            int lengthOfFirst = name.IndexOf(' ');
            int lengthOfLast = name.Length - lengthOfFirst - 1;
            string firstName = name.Substring(0, lengthOfFirst);
            string lastName = name.Substring(lengthOfFirst + 1, lengthOfLast);
            WriteLine($"First name: {firstName}, Last name: {lastName}");
            ReadOnlySpan<char> nameAsSpan = name.AsSpan();
            var firstNameSpan = nameAsSpan[0..lengthOfFirst];
            var lastNameSpan = nameAsSpan[^lengthOfLast..^0];       // ^ stands for "from end"
            WriteLine("First name: {0}, Last name: {1}", firstNameSpan.ToString(), lastNameSpan.ToString());
        }
    }
}
