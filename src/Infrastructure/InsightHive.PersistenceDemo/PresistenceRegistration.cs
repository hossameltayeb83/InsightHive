using InsightHive.Application.Interfaces.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace InsightHive.PersistenceDemo
{
    public static class PresistenceRegistration
    {
        public static IServiceCollection AddPresistenceDemoServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IReviewRepository, ReviewRepository>();
            return services;

        }
    }
}
