using System.Reflection;
using netCore.RateLimiting.Application.Services;

namespace netCore.RateLimiting.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICustomerService, CustomerManager>();
        }
    }
}
