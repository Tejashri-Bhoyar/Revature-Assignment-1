namespace CqrsMediatRDemo.Infrastructure
{
    public record CustomerCreated(Guid Id, string FirstName, string LastName, string Email);
    public record CustomerUpdated(Guid Id, string? FirstName, string? LastName, string? Email);
    public record CustomerDeleted(Guid Id);
}