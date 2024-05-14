using InsightHive.Application.Interfaces.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace InsightHive.PersistenceDemo
{
    public static class PresistenceRegistration
    {
        public static IServiceCollection AddPresistenceDemoServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ISubCategoryRepo, SubCategoryRepo>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IReviewerRepository, ReviewerRepositroy>();
            services.AddScoped<IFilterRepository, FilterRepository>();
            services.AddScoped<ISearchRepository, SearchRepository>();
            return services;

        }
    }
}
