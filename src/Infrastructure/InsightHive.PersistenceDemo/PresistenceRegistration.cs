using InsightHive.Application.Interfaces.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.PersistenceDemo
{
    public static class PresistenceRegistration
    {
        public static IServiceCollection AddPresistenceDemoServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IReviewerRepository, ReviewerRepositroy>();
            services.AddScoped<IFilterRepository,FilterRepository>();
            services.AddScoped<ISearchRepository,SearchRepository>();
            return services;

        }
    }
}
