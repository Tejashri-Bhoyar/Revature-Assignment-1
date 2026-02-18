using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// Main program
try
{
    using (var _context = new CrmContext())
    {
        // Query customers older than 20
        var customers = _context.Customers
            .Where(c => c.Age > 20)
            .ToList();

        customers.Add(new Customer{ Name= "Amit", Age=30});
        _context.SaveChanges();

        var john = _context.Customers.FirstOrDefault(c => c.Name == "John");
if (john != null) john.Age = 40;

_context.SaveChanges();

        foreach (var customer in customers)
        {
            Console.WriteLine($"Id: {customer.Id}, Name: {customer.Name}, Age: {customer.Age}");
        }
    }

}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
    if (ex.InnerException != null)
        Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
}

// DbContext
class CrmContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Make sure Trusted_Connection=True works for your SQL Server
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=CrmDb;Trusted_Connection=True;TrustServerCertificate=True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Customer>(entity =>
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Name)
              .IsRequired()
              .HasMaxLength(50);

        entity.Property(e => e.Age)
              .IsRequired();
    });
}
   
}

// order entity
public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(3)]
    public string Product { get; set; }

    [Required]
    [Precision(18, 2)]
    public decimal Price { get; set; }

    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}


// customer Entity
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}
