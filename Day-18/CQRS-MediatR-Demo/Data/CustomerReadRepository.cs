using CqrsMediatRDemo.ReadModel;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediatRDemo.Data
{
    public class CustomerReadRepository : ICustomerReadRepository
    {
        private readonly ApplicationDbContext _ctx;
        public CustomerReadRepository(ApplicationDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(CustomerDto dto, CancellationToken ct)
        {
            // for demo we store read model in same in-memory DB
            _ctx.Add(dto);
            await _ctx.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(CustomerDto dto, CancellationToken ct)
        {
            _ctx.Update(dto);
            await _ctx.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var dto = await _ctx.Set<CustomerDto>().FindAsync(new object[] { id }, ct);
            if (dto != null)
            {
                _ctx.Remove(dto);
                await _ctx.SaveChangesAsync(ct);
            }
        }

        public async Task<CustomerDto?> GetByIdAsync(Guid id, CancellationToken ct)
            => await _ctx.Set<CustomerDto>().FindAsync(new object[] { id }, ct);

        public async Task<IEnumerable<CustomerDto>> SearchAsync(string term, CancellationToken ct)
        {
            return await _ctx.Set<CustomerDto>()
                .Where(c => c.FirstName.Contains(term) || c.LastName.Contains(term) || c.Email.Contains(term))
                .ToListAsync(ct);
        }
    }
}