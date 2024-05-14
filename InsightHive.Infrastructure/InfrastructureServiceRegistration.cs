using Hangfire;
using InsightHive.Application.Interfaces.Infrastructure;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Infrastructure.Background;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services ,string HFConnectionString)
        {
            services.AddHangfire(config => config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(HFConnectionString)
            );

            services.AddHangfireServer();

            services.AddScoped<IBackgroundService,BackgroundService>();
            return services;
        }
    }
}
