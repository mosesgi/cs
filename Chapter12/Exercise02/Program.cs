using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;

using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Moses.Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                IQueryable<string> cities = db.Customers.Select(c => c.City).Distinct();
                WriteLine("A list of cities that at least one customer resides in: ");
                Write($"{string.Join(", ", cities)}");
                WriteLine();
                Write("Enter a name of a city: ");
                string city = ReadLine();
                // var customers = db.Customers.Where(c => c.City == city);
                // WriteLine($"There are {customers.Count()} customers in {city}: ");
                // foreach (var c in customers)
                // {
                //     WriteLine($"{c.CompanyName} : {c.ContactName}");
                // }
                var customersInCity = db.Customers.Where(c => c.City == city);

                WriteLine($"There are {customersInCity.Count()} customers in {city}:");
                foreach (var item in customersInCity)
                {
                    WriteLine($"{item.CompanyName} : {item.ContactName}");
                }
            }
        }
    }
}
