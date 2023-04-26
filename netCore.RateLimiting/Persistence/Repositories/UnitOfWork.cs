using netCore.RateLimiting.Application.Repositories;
using netCore.RateLimiting.Persistence.Context;

namespace netCore.RateLimiting.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BaseDbContext _context;

        public UnitOfWork(BaseDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
