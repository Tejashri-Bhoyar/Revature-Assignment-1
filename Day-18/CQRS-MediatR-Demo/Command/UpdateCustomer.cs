
using MediatR;

namespace CqrsMediatRDemo.Commands
{
    public record UpdateCustomer(
        Guid Id,
        string? FirstName,
        string? LastName,
        string? Email
    ) : IRequest;
}
