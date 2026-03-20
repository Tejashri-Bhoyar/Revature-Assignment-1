using CqrsMediatRDemo.Data;
using CqrsMediatRDemo.ReadModel;

namespace CqrsMediatRDemo.Infrastructure
{
    public class CustomerProjection :
        IEventHandler<CustomerCreated>,
        IEventHandler<CustomerUpdated>,
        IEventHandler<CustomerDeleted>
    {
        private readonly ICustomerReadRepository _read;

        public CustomerProjection(ICustomerReadRepository read)
        {
            _read = read;
        }

        public Task Handle(CustomerCreated e, CancellationToken ct)
        {
            var dto = new CustomerDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email
            };
            return _read.AddAsync(dto, ct);
        }

        public Task Handle(CustomerUpdated e, CancellationToken ct)
        {
            var dto = new CustomerDto
            {
                Id = e.Id,
                FirstName = e.FirstName ?? string.Empty,
                LastName = e.LastName ?? string.Empty,
                Email = e.Email ?? string.Empty
            };
            return _read.UpdateAsync(dto, ct);
        }

        public Task Handle(CustomerDeleted e, CancellationToken ct)
        {
            return _read.DeleteAsync(e.Id, ct);
        }
    }
}