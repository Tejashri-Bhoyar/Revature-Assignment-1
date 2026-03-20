using CqrsMediatRDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediatRDemo.Data
{
    public class CustomerWriteRepository : ICustomerWriteRepository
    {
        private readonly ApplicationDbContext _ctx;
        public CustomerWriteRepository(ApplicationDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Customer customer, CancellationToken ct)
        {
            _ctx.Customers.Add(customer);
            await _ctx.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Customer customer, CancellationToken ct)
        {
            _ctx.Customers.Update(customer);
            await _ctx.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var cust = await _ctx.Customers.FindAsync(new object[] { id }, ct);
            if (cust != null)
            {
                _ctx.Customers.Remove(cust);
                await _ctx.SaveChangesAsync(ct);
            }
        }
    }
}