using CqrsMediatRDemo.Commands;
using CqrsMediatRDemo.Data;
using CqrsMediatRDemo.Domain;
using CqrsMediatRDemo.Infrastructure;
using MediatR;

namespace CqrsMediatRDemo.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomer>
    {
        private readonly ICustomerWriteRepository _write;
        private readonly IEventBus _bus;

        public CreateCustomerHandler(ICustomerWriteRepository write, IEventBus bus)
        {
            _write = write;
            _bus = bus;
        }

        public async Task<Unit> Handle(CreateCustomer cmd, CancellationToken ct)
        {
            var customer = new Customer(cmd.Id, cmd.FirstName, cmd.LastName, cmd.Email);
            await _write.AddAsync(customer, ct);

            // publish event so projection updates read model
            var e = new CustomerCreated(cmd.Id, cmd.FirstName, cmd.LastName, cmd.Email);
            await _bus.PublishAsync(e, ct);

            return Unit.Value;
        }
    }
}