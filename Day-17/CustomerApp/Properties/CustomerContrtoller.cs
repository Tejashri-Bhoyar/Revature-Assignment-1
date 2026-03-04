using Microsoft.AspNetCore.Mvc;
using CustomerApp.Models;
using System.Collections.Generic;

namespace CustomerApp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Alice", Email = "alice@email.com" },
                new Customer { Id = 2, Name = "Bob", Email = "bob@email.com" }
            };

            return Ok(customers);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            return Created("", customer);
        }

        // [HttpPut("{id}")]
        // public IActionResult Put(int id, [FromBody] Customer updatedCustomer)
        // {
        //     if (id != updatedCustomer.Id)
        //     {
        //         return BadRequest("ID mismatch");
        //     }

        //     return Ok(updatedCustomer);
        // }
    }
}