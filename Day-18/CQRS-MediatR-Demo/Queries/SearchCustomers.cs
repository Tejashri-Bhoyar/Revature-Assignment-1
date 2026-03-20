using CqrsMediatRDemo.ReadModel;
using MediatR;

namespace CqrsMediatRDemo.Queries
{
    public record SearchCustomers(string Term) : IRequest<IEnumerable<CustomerDto>>;
}