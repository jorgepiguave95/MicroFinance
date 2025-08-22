using Microsoft.EntityFrameworkCore;

namespace Customers.Persistence
{
    public class CustomersDbContext : DbContext
    {
        public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options) { }

        public DbSet<CustomerEntity>? Customers { get; set; }
    }
}
