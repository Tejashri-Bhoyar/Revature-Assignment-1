using CqrsMediatRDemo.ReadModel;

namespace CqrsMediatRDemo.Data
{
    public interface ICustomerReadRepository
    {
        Task<CustomerDto?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<IEnumerable<CustomerDto>> SearchAsync(string term, CancellationToken ct);
        Task AddAsync(CustomerDto dto, CancellationToken ct);
        Task UpdateAsync(CustomerDto dto, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);
    }
}