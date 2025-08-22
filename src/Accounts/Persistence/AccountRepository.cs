using Accounts.Persistence;
using Microsoft.EntityFrameworkCore;
using Contracts.Accounts;
namespace Accounts.Persistence
{
    public class AccountRepository
    {
        private readonly AccountsDbContext _context;
        public AccountRepository(AccountsDbContext context)
        {
            _context = context;
        }

        public async Task<List<AccountEntity>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<AccountEntity?> GetByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<AccountEntity> CreateAsync(AccountEntity entity)
        {
            _context.Accounts.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<AccountEntity?> UpdateAsync(AccountEntity entity)
        {
            var existing = await _context.Accounts.FindAsync(entity.Id);
            if (existing == null) return null;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Accounts.FindAsync(id);
            if (entity == null) return false;
            _context.Accounts.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
