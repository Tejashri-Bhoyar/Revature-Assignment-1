using MediatR;

namespace CqrsMediatRDemo.Commands
{
    public record DeleteCustomer(Guid Id) : IRequest;
}