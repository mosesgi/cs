using System;
using System.Numerics;
using static System.Console;

namespace WorkingWithNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong largest = ulong.MaxValue;
            WriteLine($"{largest, 40:N0}");
            BigInteger atomsInTheUniverse = BigInteger.Parse("123456789012345678901234567890");
            WriteLine($"{atomsInTheUniverse, 40:N0}");
        }
    }
}
