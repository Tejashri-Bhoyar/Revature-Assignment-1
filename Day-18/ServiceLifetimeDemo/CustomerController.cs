using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
}

public interface ICustomerService
{
    public IEnumerable<Customer> Get();
}

public class CustomerService : ICustomerService
{
    CrmDbContext _context;

    public CustomerService(CrmDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Customer> Get()
    {
        throw new NotImplementedException();
    }
}

public class CrmDbContext : DbContext
{
    public CrmDbContext(DbContextOptions options) : base(options)
    {
    }
}

public class Customer
{
    public int Id {get; set;}
    public string Name {get; set;}
}