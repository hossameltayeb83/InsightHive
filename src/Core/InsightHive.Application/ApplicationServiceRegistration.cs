using FluentValidation;
using InsightHive.Application.UseCases.Categories.Command.CreateCategory;
using InsightHive.Application.UseCases.Reviews.Command.CreateReview;
using InsightHive.Application.UseCases.Reviews.Command.UpdateReview;
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
            services.AddScoped<IValidator<CreateReviewCommand>, CreateReviewCommandValidator>();
            services.AddScoped<IValidator<UpdateReviewCommand>, UpdateReviewCommandValidator>();

            return services;
        }
    }
}
