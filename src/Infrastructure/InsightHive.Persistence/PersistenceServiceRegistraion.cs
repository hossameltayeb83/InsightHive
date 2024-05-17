using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Persistence
{
    public static class PersistenceServiceRegistraion
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBusinessRepository, BusinessRepository>();
            services.AddScoped<IFilterRepository, FilterRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IReviewerRepository, ReviewerRepository>();
            return services;
        }
    }
}
