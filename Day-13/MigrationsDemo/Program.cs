using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day13EF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CrmDbContext())
            {
                // Apply migrations automatically
                context.Database.Migrate();

                // Create Customer with Orders
                var customer = new Customer
                {
                    Name = "Harsh",
                    Email = "harsh@email.com",
                    Orders = new List<Order>
                    {
                        new Order { ProductName = "Laptop", Amount = 80000 },
                        new Order { ProductName = "Keyboard", Amount = 2000 }
                    }
                };

                context.Customers.Add(customer);
                context.SaveChanges();

                Console.WriteLine("Customer and Orders saved successfully!\n");

                // Fetch Data with Relationship
                var customers = context.Customers
                    .Include(c => c.Orders)
                    .ToList();

                foreach (var c in customers)
                {
                    Console.WriteLine($"Customer: {c.Name} ({c.Email})");

                    foreach (var order in c.Orders)
                    {
                        Console.WriteLine($"   Order: {order.ProductName} - ₹{order.Amount}");
                    }
                }
            }
        }
    }

    // ==============================
    // DbContext
    // ==============================

    class CrmDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=CustomerDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }

    // ==============================
    // Customer Entity
    // ==============================

    public class Customer
    {
        public int CustomerId { get; set; }   // Primary Key

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        // Navigation Property (One-to-Many)
        public List<Order> Orders { get; set; } = new();
    }

    // ==============================
    // Order Entity
    // ==============================

    public class Order
    {
        public int OrderId { get; set; }  // Primary Key

        public string ProductName { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        // Foreign Key
        public int CustomerId { get; set; }

        // Navigation Property
        public Customer Customer { get; set; } = null!;
    }
}