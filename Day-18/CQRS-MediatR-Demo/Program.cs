using CqrsMediatRDemo.Data;
using CqrsMediatRDemo.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseInMemoryDatabase("CustomerDb"));

builder.Services.AddMediatR(typeof(Program));
// register read/write repositories and event bus
builder.Services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
builder.Services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
builder.Services.AddSingleton<IEventBus, InMemoryEventBus>();

// register projection handler
builder.Services.AddScoped<CustomerProjection>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();