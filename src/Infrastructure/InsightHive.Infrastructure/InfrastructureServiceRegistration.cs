using InsightHive.Application.Interfaces.Infrastructure;
using InsightHive.Infrastructure.Background;
using Microsoft.Extensions.DependencyInjection;

namespace InsightHive.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // complete Configration
            services.AddTransient<IBackgroundService, BackgroundService>();
            return services;
        }
    }
}
