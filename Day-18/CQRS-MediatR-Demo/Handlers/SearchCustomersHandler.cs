using CqrsMediatRDemo.Data;
using CqrsMediatRDemo.Queries;
using CqrsMediatRDemo.ReadModel;
using MediatR;

namespace CqrsMediatRDemo.Handlers
{
    public class SearchCustomersHandler : IRequestHandler<SearchCustomers, IEnumerable<CustomerDto>>
    {
        private readonly ICustomerReadRepository _read;
        public SearchCustomersHandler(ICustomerReadRepository read) => _read = read;

        public Task<IEnumerable<CustomerDto>> Handle(SearchCustomers q, CancellationToken ct)
            => _read.SearchAsync(q.Term, ct);
    }
}