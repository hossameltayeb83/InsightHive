
using Hangfire;
using InsightHive.Api.Middleware;
using InsightHive.Application;
using InsightHive.Identity;
using InsightHive.Infrastructure;
using InsightHive.Persistence;
using Microsoft.OpenApi.Models;

namespace InsightHive.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplicationServices()
                            .AddIdentityServices(builder.Configuration)
                            .AddPersistenceServices(builder.Configuration)
                            .AddInfrastructureServices(builder.Configuration);


            builder.Services.AddCors(
                 options => options.AddPolicy(
                     "angularApp",
                     policy => policy.WithOrigins(builder.Configuration["AngularUrl"] ?? "https://localhost:7020")
             .AllowAnyMethod()
             .SetIsOriginAllowed(pol => true)
             .AllowAnyHeader()
             .AllowCredentials()));

            builder.Services.AddControllers()
                            .ConfigureApiBehaviorOptions(options =>
                            {
                                options.SuppressMapClientErrors = true;
                            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                        },
                        new string[]{ }
                    }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.MapIdentityApi<AppUser>();

            app.UseExceptionHandlerMiddleware();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("angularApp");
            app.MapControllers();

            app.UseHangfireDashboard();
            app.MapHangfireDashboard("/admin/hangfire");

            app.Run();
        }
    }
}
