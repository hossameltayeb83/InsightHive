using InsightHive.Application.Interfaces.Identity;
using InsightHive.Identity.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InsightHive.Identity
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                options.DefaultChallengeScheme =
                options.DefaultForbidScheme =
                options.DefaultScheme =
                options.DefaultSignInScheme =
                options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!)),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });

            services.AddAuthorizationCore(opt =>
            {
                opt.AddPolicy(PolicyData.AdminPolicyName, p => p.RequireClaim(PolicyData.RoleClaimName, PolicyData.AdminClaimValue));
                opt.AddPolicy(PolicyData.OwnerPolicyName, p => p.RequireClaim(PolicyData.RoleClaimName, PolicyData.OwnerClaimValue));
                opt.AddPolicy(PolicyData.UserPolicyName, p => p.RequireClaim(PolicyData.RoleClaimName, PolicyData.UserClaimValue));
            });

            services.AddScoped<IJwtFactory, JwtFactory>();

            return services;
        }
    }
}
