using System.IO;
using Microsoft.EntityFrameworkCore;
using static System.Console;

namespace Moses.Exercise
{
    public class Northwind : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine("..", "..", "db", "Northwind.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
}