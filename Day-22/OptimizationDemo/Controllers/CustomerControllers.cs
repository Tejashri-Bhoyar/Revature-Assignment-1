using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        // Database
        var customers = await dbContext.Customers.ToListAsync();

        return await Task.FromResult(Ok(customers));
    }
}

