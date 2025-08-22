using Microsoft.EntityFrameworkCore;
namespace Customers.Persistence
{
    public class CustomerRepository
    {
        private readonly CustomersDbContext _context;

        public CustomerRepository(CustomersDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerEntity>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<CustomerEntity?> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<CustomerEntity> CreateAsync(CustomerEntity entity)
        {
            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CustomerEntity?> UpdateAsync(CustomerEntity entity)
        {
            var existing = await _context.Customers.FindAsync(entity.Id);
            if (existing == null) return null;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Customers.FindAsync(id);
            if (entity == null) return false;
            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
