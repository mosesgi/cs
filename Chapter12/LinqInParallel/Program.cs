using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

using static System.Console;

namespace LinqInParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
            Write("Press ENTER to start: ");
            ReadLine();
            watch.Start();
            IEnumerable<int> numbers = Enumerable.Range(1, 2_000_000_000);
            var squares = numbers
                // .AsParallel()
                .Select(number => number * number).ToArray();
            // In MacbookPro with 12 cores, non-parallel cost 12371 ms, but parallel cost 56801 ms!! WTF!
            watch.Stop();
            WriteLine("{0:#,##0} elapsed milliseconds.", arg0: watch.ElapsedMilliseconds);
        }
    }
}
