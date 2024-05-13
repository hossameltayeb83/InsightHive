﻿using InsightHive.Application.Interfaces.Persistence;
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
            return services;

        }
    }
}
