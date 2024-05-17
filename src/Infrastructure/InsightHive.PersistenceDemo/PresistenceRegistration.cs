using InsightHive.Application.Interfaces.Persistence;
using InsightHive.PersistenceDemo.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InsightHive.PersistenceDemo
{
    public static class PresistenceRegistration
    {
        public static IServiceCollection AddPresistenceDemoServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReviewReactionRepository, ReviewReactopnRepository>();
            services.AddScoped<IReviewerRepository, ReviewerRepository>();
            services.AddScoped<IFilterRepository, FilterRepository>();
            services.AddScoped<ISearchRepository, SearchRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepo>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IReviewerRepository, ReviewerRepositroy>();
            services.AddScoped<IFilterRepository, FilterRepository>();
            return services;

        }
    }
}
