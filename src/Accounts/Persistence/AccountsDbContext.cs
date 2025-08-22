using Microsoft.EntityFrameworkCore;
using Accounts.Persistence;

namespace Accounts.Persistence
{
    public class AccountsDbContext : DbContext
    {
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options) : base(options) { }

        public DbSet<AccountEntity>? Accounts { get; set; }
    }
}
