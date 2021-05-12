using System;
using System.Xml.Linq;
using static System.Console;

namespace AssembliesAndNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new XDocument();

            string s1 = "Hello";
            String s2 = "World";
            WriteLine($"{s1} {s2}");
        }
    }
}
