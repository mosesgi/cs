using System;
using static System.Console;

namespace Exercise04
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter a number between 0 and 255: ");
            string first = ReadLine();
            Write("Enter another number between 0 and 255: ");
            string second = ReadLine();
            try
            {
                byte num1 = byte.Parse(first);
                byte num2 = byte.Parse(second);
                double result = ((double)num1)/num2;
                WriteLine($"{num1} divided by {num2} is {result}");
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType().Name} : {ex.Message}");
            }
        }
    }
}
