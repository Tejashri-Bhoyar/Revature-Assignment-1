using CqrsMediatRDemo.Commands;
using CqrsMediatRDemo.Data;
using MediatR;

namespace CqrsMediatRDemo.Handlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomer>
    {
        private readonly ICustomerWriteRepository _write;
        private readonly IEventBus _bus;

        public UpdateCustomerHandler(ICustomerWriteRepository write, IEventBus bus)
        {
            _write = write;
            _bus = bus;
        }

        public async Task<Unit> Handle(UpdateCustomer cmd, CancellationToken ct)
        {
            // read existing entity directly from DB - not ideal for big systems
            var existing = new CqrsMediatRDemo.Domain.Customer(cmd.Id, cmd.FirstName ?? string.Empty, cmd.LastName ?? string.Empty, cmd.Email ?? string.Empty);
            // you could load from repository and apply changes instead
            await _write.UpdateAsync(existing, ct);

            var e = new CustomerUpdated(cmd.Id, cmd.FirstName, cmd.LastName, cmd.Email);
            await _bus.PublishAsync(e, ct);

            return Unit.Value;
        }
    }
}