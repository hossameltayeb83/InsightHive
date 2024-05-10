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
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // complete Configration
            services.AddTransient<IBackgroundService,BackgroundService>();
            return services;
        }
    }
}
