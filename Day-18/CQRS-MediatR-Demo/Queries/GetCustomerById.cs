using CqrsMediatRDemo.ReadModel;
using MediatR;

namespace CqrsMediatRDemo.Queries
{
    public record GetCustomerById(Guid Id) : IRequest<CustomerDto?>;
}