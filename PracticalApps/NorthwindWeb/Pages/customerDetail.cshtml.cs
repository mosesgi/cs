using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using System.Diagnostics;
using System;
using Microsoft.EntityFrameworkCore;

namespace NorthwindWeb.Pages
{
    public class CustomerDetailModel : PageModel
    {
        private Northwind db;
        public Customer Customer { get; set; }

        public CustomerDetailModel(Northwind dbContext)
        {
            this.db = dbContext;
        }

        public void OnGet()
        {
            string customerID = Request.Query["id"];
            if (string.IsNullOrEmpty(customerID))
            {
                Customer = new Customer {
                    ContactName="Not exist"
                };
                return;
            }
            Customer = db.Customers
                .Include(c => c.Orders)
                    .ThenInclude(o => o.OrderDetails)
                        .ThenInclude(item => item.Product)
                .SingleOrDefault(x => x.CustomerID == customerID);
            ViewData["Title"] = $"Detail Customer - {Customer.ContactName}";
        }
    }
}