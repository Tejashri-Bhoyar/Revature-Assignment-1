using CqrsMediatRDemo.Domain;

namespace CqrsMediatRDemo.Data
{
    public interface ICustomerWriteRepository
    {
        Task AddAsync(Customer customer, CancellationToken ct);
        Task UpdateAsync(Customer customer, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);
    }
}