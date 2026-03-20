
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();

// register DbContext and CustomerService
builder.Services.AddScoped<CrmDbContext>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

// AutoMapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<CustomerProfile>();
});

// Fluent Validation
builder.Services.AddScoped<IValidator<CreateCustomerDTO>, CreateCustomerDTOValidator>();
builder.Services.AddScoped<IValidator<CreateCustomerDTO>, UKNameCreateCustomerDTOValidator>();

// Add Sql Server
// builder.Services.AddDbContext<CrmDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("CrmDbConnection")));
builder.Services.AddDbContextPool<CrmDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CrmDbConnection"))
    , poolSize: 128);

// builder.Services.AddMemoryCache();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
});

var app = builder.Build();

app.Use(async (context, next) =>
{

    // Get the full request URL
    var request = context.Request;
    var requestUrl = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}";

    // Add it to response header
    context.Response.Headers["Request-Url"] = requestUrl;

        // Execute the rest of the pipeline first
    await next();

});

app.UseRouting();

app.MapControllers();


app.Run();