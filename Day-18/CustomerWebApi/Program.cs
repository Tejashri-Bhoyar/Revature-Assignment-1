var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/v1/customer", () =>
{
    return new[]
    {
        new { Id = 1, Name = "Harshu" },
        new { Id = 2, Name = "Rahul" }
    };
});

app.Run("http://localhost:5250");