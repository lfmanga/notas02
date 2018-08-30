using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Notas02.Application.UserManager.Configurations;
using Notas02.Application.UserManager.Identity.Context;
using Notas02.Application.UserManager.Identity.Models;
using System;

namespace Notas02.Application.UserManager
{
    public static class UserManagerStartupExtensions
    {
        public static IServiceCollection AddUserManager(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Notas02IdentityContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<Notas02User, IdentityRole>()
                .AddEntityFrameworkStores<Notas02IdentityContext>()
                .AddDefaultTokenProviders();


            var signingConfigurations = new SigningConfiguration();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfiguration();
            (new ConfigureFromConfigurationOptions<TokenConfiguration>(configuration.GetSection("TokenConfigurations"))).Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            AddJwt(services, signingConfigurations, tokenConfigurations);

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = "1093397758825-arnemikov0nc8i2v8gqt702n9efn1h6c.apps.googleusercontent.com";
                googleOptions.ClientSecret = "khmduMMWOOwnBk9EB8FL8QVO";
            });

            return services;
        }

        public static IApplicationBuilder UseUserManager(this IApplicationBuilder app, UserManager<Notas02User> userManager, RoleManager<IdentityRole> roleManager)
        {
            (new UserManagerInitializer(userManager, roleManager)).Initialize();
            return app;
        }

        private static void AddJwt(IServiceCollection services, SigningConfiguration signingConfigurations, TokenConfiguration tokenConfigurations)
        {
            services
            .AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });
        }
    }
}
