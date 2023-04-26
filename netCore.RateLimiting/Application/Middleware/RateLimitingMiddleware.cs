using AspNetCoreRateLimit;

namespace netCore.RateLimiting.Application.Middleware
{
    public static class RateLimitingMiddleware
    {
        public static void AddRateLimitingServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IpRateLimitOptions>(options => configuration.GetSection("RateLimitingSettings").Bind(options));
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.AddMemoryCache();
        }

        public static void UseRateLimiting(this IApplicationBuilder app)
        {
            app.UseIpRateLimiting();
        }
    }
}
