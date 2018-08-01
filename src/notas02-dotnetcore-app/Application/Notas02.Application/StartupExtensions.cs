using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notas02.Application.Core.Contracts.Repository;
using Notas02.Application.Data.Dapper;
using Notas02.Application.EF.Context;
using Notas02.Application.EF.Repository;
using Notas02.Application.UserManager;
using Notas02.Application.UserManager.Identity.Models;
using System;

namespace Notas02.Application
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddNotas02Application(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = AppDomain.CurrentDomain.Load("Notas02.Application");
            services.AddMediatR(assembly);
            services.AddScoped<Notas02Context>();
            services.AddScoped(typeof(IReadRepository<>), typeof(DapperReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(EFWriteRepository<>));
            services.AddUserManager(configuration);
            return services;
        }

        public static IApplicationBuilder UseNotas02Application(this IApplicationBuilder app, UserManager<Notas02User> userManager, RoleManager<IdentityRole> roleManager)
        {
            app.UseUserManager(userManager, roleManager);
            return app;
        }
    }
}