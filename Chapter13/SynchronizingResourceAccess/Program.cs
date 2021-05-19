using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using static System.Console;

namespace SynchronizingResourceAccess
{
    class Program
    {
        static Random r = new Random();
        static string Message;  //a shared resource
        static object conch = new object();
        static int Counter;  //another shared resource

        static void MethodA()
        {
            // lock (conch)
            // {
            //     for (int i = 0; i < 5; i++)
            //     {
            //         Thread.Sleep(r.Next(2000));
            //         Message += "A";
            //         Write(".");
            //     }
            // }
            try
            {
                if (Monitor.TryEnter(conch, TimeSpan.FromSeconds(15)))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(r.Next(2000));
                        Message += "A";
                        Interlocked.Increment(ref Counter);
                        Write(".");
                    }
                }
                else
                {
                    WriteLine("Method A failed to enter a monitor lock.");
                }
            }
            finally
            {
                Monitor.Exit(conch);
            }
        }

        static void MethodB()
        {
            /* lock (conch)
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(r.Next(2000));
                    Message += "B";
                    Write(".");
                }
            } */
            try
            {
                if (Monitor.TryEnter(conch, TimeSpan.FromSeconds(15)))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(r.Next(2000));
                        Message += "B";
                        Interlocked.Increment(ref Counter);
                        Write(".");
                    }
                }
                else
                {
                    WriteLine("Method B failed to enter a monitor lock.");
                }
            }
            finally
            {
                Monitor.Exit(conch);
            }
        }

        static void Main(string[] args)
        {
            WriteLine("Please wait for the tasks to complete.");
            Stopwatch watch = Stopwatch.StartNew();
            Task a = Task.Factory.StartNew(MethodA);
            Task b = Task.Factory.StartNew(MethodB);
            Task.WaitAll(new Task[] { a, b });
            WriteLine();
            WriteLine($"Results: {Message}.");
            WriteLine($"{Counter} string modification");
            WriteLine($"{watch.ElapsedMilliseconds:#,##0} elapsed milliseconds.");
        }
    }
}
