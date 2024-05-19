using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Identity.Models;
using InsightHive.Persistence.Data;
using InsightHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InsightHive.Persistence
{
    public static class PersistenceServiceRegistraion
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<InsightHiveDbContext>(c =>
            {
                c.UseSqlServer(config.GetConnectionString("DevConnection"));
            });

            services.AddIdentityCore<AppUser>()
                    .AddEntityFrameworkStores<InsightHiveDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBusinessRepository, BusinessRepository>();
            services.AddScoped<IFilterRepository, FilterRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IReviewerRepository, ReviewerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBadgeRepository, BadgeRepository>();
            services.AddScoped<IReviewReactionRepository, ReviewReactionRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            return services;
        }
    }
}
