using MediatR;

namespace CqrsMediatRDemo.Commands
{
    public record CreateCustomer(
        Guid Id,
        string FirstName,
        string LastName,
        string Email
    ) : IRequest;
}