using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using System.Diagnostics;
using System.Collections.Immutable;

namespace NorthwindWeb.Pages
{
    public class CustomersModel : PageModel
    {
        private Northwind db;
        public IDictionary<string, List<Customer>> Customers { get; set; }

        public CustomersModel(Northwind dbContext)
        {
            this.db = dbContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Customers Grouped by Country";
            Customers = db.Customers.AsEnumerable()
                .GroupBy(c => c.Country).OrderBy(g => g.Key)
                .ToImmutableSortedDictionary(g => g.Key, g => g.OrderBy(c => c.ContactName).ToList());
            foreach(var entry in Customers)
            {
                Trace.WriteLine("Customers in Country {0}:", entry.Key);
                foreach(var customer in entry.Value)
                {
                    Trace.WriteLine($"  {customer.ContactName} - {customer.CustomerID}");
                }
            }
        }
    }
}