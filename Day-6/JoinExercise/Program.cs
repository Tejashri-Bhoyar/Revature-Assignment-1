using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerOrderApp
{
    // Customer Class
    class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    // Order Class
    class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public double Amount { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Customer List
            List<Customer> customers = new List<Customer>
            {
                new Customer { CustomerId = 1, Name = "Rahul" },
                new Customer { CustomerId = 2, Name = "Amit" },
                new Customer { CustomerId = 3, Name = "Neha" }
            };

            // Order List
            List<Order> orders = new List<Order>
            {
                new Order { OrderId = 101, CustomerId = 1, Amount = 5000 },
                new Order { OrderId = 102, CustomerId = 1, Amount = 2000 },
                new Order { OrderId = 103, CustomerId = 2, Amount = 3000 },
                new Order { OrderId = 104, CustomerId = 2, Amount = 1500 },
                new Order { OrderId = 105, CustomerId = 3, Amount = 4000 }
            };

            // ------------------ JOIN QUERY ------------------

            var joinResult =
                from c in customers
                join o in orders
                on c.CustomerId equals o.CustomerId
                select new
                {
                    CustomerName = c.Name,
                    OrderId = o.OrderId,
                    Amount = o.Amount
                };

            Console.WriteLine("Customer Orders:");
            Console.WriteLine("----------------");

            foreach (var item in joinResult)
            {
                Console.WriteLine($"Customer: {item.CustomerName}, Order ID: {item.OrderId}, Amount: {item.Amount}");
            }

            Console.WriteLine();

            // ------------------ GROUP & TOTAL ------------------

            var summary =
                from c in customers
                join o in orders
                on c.CustomerId equals o.CustomerId
                group o by c.Name into g
                select new
                {
                    CustomerName = g.Key,
                    TotalOrders = g.Count(),
                    TotalAmount = g.Sum(x => x.Amount)
                };

            Console.WriteLine("Customer Summary:");
            Console.WriteLine("-----------------");

            foreach (var item in summary)
            {
                Console.WriteLine($"Customer: {item.CustomerName}");
                Console.WriteLine($"Total Orders: {item.TotalOrders}");
                Console.WriteLine($"Total Amount: {item.TotalAmount}");
                Console.WriteLine();
            }

            Console.WriteLine("Program Completed.");
        }
    }
}
