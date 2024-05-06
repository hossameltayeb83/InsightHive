
using InsightHive.Application;
using InsightHive.PersistenceDemo;

namespace InsightHive.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddApplicationServices().AddPresistenceDemoServices();

            builder.Services.AddCors(
                 options => options.AddPolicy(
                     "angularApp",
                     policy => policy.WithOrigins(builder.Configuration["AngularUrl"] ?? "https://localhost:7020")
             .AllowAnyMethod()
             .SetIsOriginAllowed(pol => true)
             .AllowAnyHeader()
             .AllowCredentials()));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("angularApp");
            app.MapControllers();

            app.Run();
        }
    }
}