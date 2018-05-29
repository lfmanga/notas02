using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notas02.Application.Core.Contracts.Repository;
using Notas02.Application.EF.Context;
using Notas02.Application.EF.Repository;
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
            services.AddScoped(typeof(INotas02Repository<>), typeof(Notas02Repository<>));
            return services;
        }

        public static IApplicationBuilder UseNotas02Application(this IApplicationBuilder app)
        {
            return app;
        }
    }
}