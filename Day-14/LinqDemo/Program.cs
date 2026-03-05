using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        using var context = new CrmDbContext();

        // Ensure database & tables exist
        context.Database.EnsureCreated();

        SeedData(context);

        // ---------------- BASIC QUERIES ----------------
        BasicFiltering(context);
        JoinQueries(context);

        // ---------------- LOADING STRATEGIES ----------------
        EagerLoadingDemo(context);
        LazyLoadingDemo(context);
        ExplicitLoadingDemo(context);

        // ---------------- GROUPING & AGGREGATION ----------------
        GroupingDemo(context);

        // ---------------- PROJECTION ----------------
        ProjectionDemo(context);
    }

    // ============================================================
    // 1️⃣ DATA SEEDING WITH TRANSACTION
    // ============================================================
    static void SeedData(CrmDbContext context)
    {
        if (context.Customers.Any())
            return;

        Console.WriteLine("\n===== TRANSACTION DEMO =====");

        using var transaction = context.Database.BeginTransaction();

        try
        {
            var tempCustomer = new Customer
            {
                Name = "TempUser",
                Email = "temp@gmail.com",
                City = "TestCity"
            };

            context.Customers.Add(tempCustomer);
            context.SaveChanges();

            context.Orders.Add(new Order
            {
                CustomerId = tempCustomer.CustomerId,
                TotalAmount = 9999
            });

            context.SaveChanges();

            transaction.Commit();
            Console.WriteLine("Transaction Committed Successfully!");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine("Transaction Rolled Back!");
            Console.WriteLine(ex.Message);
        }
    }

    // ============================================================
    // 2️⃣ BASIC FILTERING
    // ============================================================
    static void BasicFiltering(CrmDbContext context)
    {
        Console.WriteLine("\n===== BASIC FILTERING =====");

        var customersFromPune = context.Customers
            .Where(c => c.City == "Pune")
            .OrderBy(c => c.Name)
            .Select(c => new { c.Name, c.Email })
            .ToList();

        foreach (var c in customersFromPune)
        {
            Console.WriteLine($"{c.Name} - {c.Email}");
        }
    }

    // ============================================================
    // 3️⃣ JOIN QUERIES
    // ============================================================
    static void JoinQueries(CrmDbContext context)
    {
        Console.WriteLine("\n===== JOIN (Query Syntax) =====");

        var querySyntax =
            from c in context.Customers
            join o in context.Orders
                on c.CustomerId equals o.CustomerId
            where o.TotalAmount > 1000
            orderby c.Name
            select c;

        foreach (var customer in querySyntax)
        {
            Console.WriteLine(customer.Name);
        }

        Console.WriteLine("\n===== JOIN (Method Syntax) =====");

        var methodSyntax = context.Customers
            .Join(context.Orders,
                  c => c.CustomerId,
                  o => o.CustomerId,
                  (c, o) => new { c, o })
            .Where(x => x.o.TotalAmount > 1000)
            .OrderBy(x => x.c.Name)
            .Select(x => x.c)
            .ToList();

        foreach (var customer in methodSyntax)
        {
            Console.WriteLine(customer.Name);
        }
    }

    // ============================================================
    // 4️⃣ LOADING STRATEGIES
    // ============================================================
    static void EagerLoadingDemo(CrmDbContext context)
    {
        Console.WriteLine("\n===== EAGER LOADING =====");

        var customers = context.Customers
            .Include(c => c.Orders)
            .ToList();

        foreach (var customer in customers)
        {
            Console.WriteLine($"Customer: {customer.Name}");
            foreach (var order in customer.Orders)
            {
                Console.WriteLine($"   Order Amount: {order.TotalAmount}");
            }
        }
    }

    static void LazyLoadingDemo(CrmDbContext context)
    {
        Console.WriteLine("\n===== LAZY LOADING =====");

        var customers = context.Customers.ToList();

        foreach (var customer in customers)
        {
            Console.WriteLine($"Customer: {customer.Name}");
            foreach (var order in customer.Orders)
            {
                Console.WriteLine($"   Order Amount: {order.TotalAmount}");
            }
        }
    }

    static void ExplicitLoadingDemo(CrmDbContext context)
    {
        Console.WriteLine("\n===== EXPLICIT LOADING =====");

        var customer = context.Customers
            .First(c => c.Name == "Harsh");

        context.Entry(customer)
               .Collection(c => c.Orders)
               .Load();

        Console.WriteLine($"Customer: {customer.Name}");

        foreach (var order in customer.Orders)
        {
            Console.WriteLine($"   Order Amount: {order.TotalAmount}");
        }
    }

    // ============================================================
    // 5️⃣ GROUPING & AGGREGATION
    // ============================================================
    static void GroupingDemo(CrmDbContext context)
    {
        Console.WriteLine("\n===== GROUPING: CUSTOMERS BY CITY =====");

        var customersByCity = context.Customers
            .GroupBy(c => c.City)
            .Select(g => new
            {
                City = g.Key,
                TotalCustomers = g.Count()
            })
            .ToList();

        foreach (var group in customersByCity)
        {
            Console.WriteLine($"City: {group.City} | Customers: {group.TotalCustomers}");
        }

        Console.WriteLine("\n===== GROUPING: ORDERS BY CUSTOMER =====");

        var orderStats = context.Orders
            .GroupBy(o => o.CustomerId)
            .Select(g => new
            {
                CustomerId = g.Key,
                OrderCount = g.Count(),
                TotalAmount = g.Sum(o => (double)o.TotalAmount),
                AverageAmount = g.Average(o => (double)o.TotalAmount),
                MinAmount = g.Min(o => (double)o.TotalAmount),
                MaxAmount = g.Max(o => (double)o.TotalAmount)
            })
            .ToList();

        foreach (var stat in orderStats)
        {
            Console.WriteLine($"CustomerId: {stat.CustomerId}");
            Console.WriteLine($"   Orders: {stat.OrderCount}");
            Console.WriteLine($"   Total: {stat.TotalAmount}");
            Console.WriteLine($"   Avg: {stat.AverageAmount}");
            Console.WriteLine($"   Min: {stat.MinAmount}");
            Console.WriteLine($"   Max: {stat.MaxAmount}");
        }
    }

    // ============================================================
    // 6️⃣ PROJECTION
    // ============================================================
    static void ProjectionDemo(CrmDbContext context)
    {
        Console.WriteLine("\n===== PROJECTION: BASIC INFO =====");

        var projectedCustomers = context.Customers
            .Select(c => new
            {
                CustomerName = c.Name,
                Location = c.City
            })
            .ToList();

        foreach (var c in projectedCustomers)
        {
            Console.WriteLine($"Name: {c.CustomerName} | City: {c.Location}");
        }
    }
}

// ============================================================
// DB CONTEXT
// ============================================================
public class CrmDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlite("Data Source=crm.db")
            .LogTo(Console.WriteLine, LogLevel.Information);
    }
}

// ============================================================
// ENTITIES
// ============================================================
public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;

    // Navigation Property
    public virtual List<Order> Orders { get; set; } = new();
}

public class Order
{
    public int OrderId { get; set; }
    public decimal TotalAmount { get; set; }

    // Foreign Key
    public int CustomerId { get; set; }

    // Navigation Property
    public virtual Customer Customer { get; set; } = null!;
}
