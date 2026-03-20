using CqrsMediatRDemo.Commands;
using CqrsMediatRDemo.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatRDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomersController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomer cmd)
        {
            await _mediator.Send(cmd);
            return CreatedAtAction(nameof(GetById), new { id = cmd.Id }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dto = await _mediator.Send(new GetCustomerById(id));
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            var results = await _mediator.Send(new SearchCustomers(term));
            return Ok(results);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateCustomer model)
        {
            await _mediator.Send(model with { Id = id });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteCustomer(id));
            return NoContent();
        }
    }
}