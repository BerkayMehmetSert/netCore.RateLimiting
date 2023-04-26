using Microsoft.EntityFrameworkCore;
using netCore.RateLimiting.Application.Repositories;
using netCore.RateLimiting.Persistence.Context;
using netCore.RateLimiting.Persistence.Repositories;

namespace netCore.RateLimiting.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<BaseDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "RateLimitingDb");
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
