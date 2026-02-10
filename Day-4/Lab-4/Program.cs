// See https://aka.ms/new-console-template for more information

// See https://aka.ms/new-console-template for more information
using System;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        // Create DI container
        var services = new ServiceCollection();

        // Register dependencies
        services.AddSingleton<IRepository<string>, InMemoryRepository<string>>();
        services.AddTransient<ProductService>();

        // Build provider
        var provider = services.BuildServiceProvider();

        // Resolve service
        var productService = provider.GetRequiredService<ProductService>();

        // Use service
        productService.AddProduct("Laptop");
        productService.AddProduct("Phone");

        Console.WriteLine("Products:");
        foreach (var product in productService.GetProducts())
        {
            Console.WriteLine(product);
        }
    }
}