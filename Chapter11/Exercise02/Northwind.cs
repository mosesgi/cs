using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace Moses.Exercise
{
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(System.Environment.CurrentDirectory, "../../db/Northwind.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>();
            modelBuilder.Entity<Product>()
            .Property(product => product.Cost)
            .HasConversion<double>();
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.Discontinued);
        }
    }
}