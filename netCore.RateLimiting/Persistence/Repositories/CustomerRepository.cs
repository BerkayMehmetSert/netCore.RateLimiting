using netCore.RateLimiting.Application.Repositories;
using netCore.RateLimiting.Models.Entities;
using netCore.RateLimiting.Persistence.Context;

namespace netCore.RateLimiting.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, BaseDbContext>, ICustomerRepository
    {
        public CustomerRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
