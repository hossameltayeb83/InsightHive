using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.UseCases.Categories.Command.CreateCategory;
using InsightHive.Application.UseCases.Filters.Command.CreateFilter;
using InsightHive.Application.UseCases.Filters.Command.UpdateFilter;
using Microsoft.Extensions.DependencyInjection;

namespace InsightHive.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddScoped<IValidator<CreateCategoryCommand>, CreateCategoryCommandValidator>();
            services.AddScoped<IValidator<CreateFilterCommand>, CreateFilterCommandValidator>();
            services.AddScoped<IValidator<UpdateFilterCommand>, UpdateFilterCommandValidator>();

            return services;
        }
    }
}
