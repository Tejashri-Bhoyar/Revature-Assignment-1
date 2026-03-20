using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();

// register DbContext and CustomerService

// AutoMapper

// Fluent Validation

// Add Sql Server

var app = builder.Build();

app.UseRouting();

app.MapControllers();

app.Run();