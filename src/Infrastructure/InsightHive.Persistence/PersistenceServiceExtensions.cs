using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Identity.Models;
using InsightHive.Persistence.Data;
using InsightHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InsightHive.Identity
{
    public static class PersistenceServiceExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<InsightHiveDbContext>(c =>
            {
                c.UseSqlServer(config.GetConnectionString("DevConnection"));
            });

            services.AddIdentityCore<AppUser>()
                    .AddEntityFrameworkStores<InsightHiveDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBadgeRepository, BadgeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFilterRepository, FilterRepository>();
            services.AddScoped<IReviewerRepository, ReviewerRepository>();
            services.AddScoped<IReviewReactionRepository, ReviewReactionRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ISearchRepository, SearchRepository>();
            return services;
        }
    }
}
