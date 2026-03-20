using CqrsMediatRDemo.Commands;
using CqrsMediatRDemo.Data;
using MediatR;

namespace CqrsMediatRDemo.Handlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomer>
    {
        private readonly ICustomerWriteRepository _write;
        private readonly IEventBus _bus;

        public DeleteCustomerHandler(ICustomerWriteRepository write, IEventBus bus)
        {
            _write = write;
            _bus = bus;
        }

        public async Task<Unit> Handle(DeleteCustomer cmd, CancellationToken ct)
        {
            await _write.DeleteAsync(cmd.Id, ct);
            await _bus.PublishAsync(new CustomerDeleted(cmd.Id), ct);
            return Unit.Value;
        }
    }
}