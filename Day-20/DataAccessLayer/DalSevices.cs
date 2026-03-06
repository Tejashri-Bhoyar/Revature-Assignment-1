using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
  public static class DalServices
 {
    public static IServiceCollection AddDataAccessLayer(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Register DbContext correctly
        services.AddDbContext<CrmDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("CrmDbConnection")));

        // Register Services
        services.AddScoped<ICustomerService, CustomerService>();

        // Register FluentValidation (ONLY ONE)
        services.AddScoped<IValidator<CreateCustomerDTO>, CreateCustomerDTOValidator>();

        return services;
    }
  }
}