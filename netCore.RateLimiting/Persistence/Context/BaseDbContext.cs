using Microsoft.EntityFrameworkCore;
using netCore.RateLimiting.Models.Entities;

namespace netCore.RateLimiting.Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
