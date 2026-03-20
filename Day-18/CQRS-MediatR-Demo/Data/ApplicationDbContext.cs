using CqrsMediatRDemo.Domain;
using CqrsMediatRDemo.ReadModel;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediatRDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<CustomerDto> CustomerReadModels => Set<CustomerDto>();
    }
}