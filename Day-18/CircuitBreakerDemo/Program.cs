
﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Polly;
using Polly.CircuitBreaker;
using Polly.Timeout;

HttpClient client = new HttpClient();
int failureCount = 0;

// CircuitBreakerDemo();

var _retryPolicy = Policy
    .Handle<HttpRequestException>()
    .WaitAndRetryAsync(3, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt))); // Exponential backoff

await _retryPolicy.ExecuteAsync(async () =>
        {
            Console.WriteLine("Attemping to call external service...");
            Console.WriteLine($"Time: {DateTime.Now}");
            var response = await client.GetAsync("http://localhost:5000/customer");
            response.EnsureSuccessStatusCode();
            var result =await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Result: {result}");
            await Task.FromResult(0);
        });

Console.ReadKey();

async void CircuitBreakerDemo()
{

    // Simulate a failing service
    var circuitBreakerPolicy = Policy
        .Handle<HttpRequestException>()
        .CircuitBreakerAsync(
            exceptionsAllowedBeforeBreaking: 2,
            durationOfBreak: TimeSpan.FromSeconds(10),
            onBreak: (ex, breakDelay) =>
            {
                Console.WriteLine($"State: Open. Circuit broken! Will retry after {breakDelay.TotalSeconds} seconds.");
            },
            onReset: () =>
            {
                Console.WriteLine("State: Close. Circuit reset. Service is healthy again.");
            },
            onHalfOpen: () =>
            {
                Console.WriteLine("State: Half-open. Testing service...");
            }
        );

    for (int i = 0; i < 1000; i++)
    {
        var result = await CallExternalService();
    }
    try
    {
        await circuitBreakerPolicy.ExecuteAsync(async () =>
        {
            var result = await CallExternalService();
            Console.WriteLine(result);
        });
        Console.WriteLine("Request successful.");
    }
    catch (BrokenCircuitException)
    {
        Console.WriteLine("Circuit is open. Skipping request.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Request failed: {ex.Message}");
    }

    await Task.Delay(1000); // Wait 1 second between requests
}

async Task<string> CallExternalService()
{
    var response = await client.GetAsync("http://localhost:5000/customer");
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadAsStringAsync();
}
