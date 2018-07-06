//using DemoJwt.Application.Contracts;
//using DemoJwt.Application.Core;
//using DemoJwt.Application.Services;
//using DemoJwt.Repository;
using Demo.APIDistancia.Repository;
using Demo.APIDistancia.Domain.Interfaces.Repositories;
using Demo.APIDistancia.Application.Interfaces.Services;
using Demo.APIDistancia.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using Demo.APIDistancia.Repository.Repository;
using Demo.APIDistancia.Repository.Config;

namespace Demo.APIDistancia.IoC
{
    public class Container
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application
            services.AddScoped<IUsuarioAcessoService, UsuarioAcessoService>();
            services.AddScoped<IAmigoService, AmigoService>();
            services.AddScoped<ICalculoHistoricoLogService, CalculoHistoricoLogService>();

            // Repository
            services.AddScoped<IUsuarioAcessoRepository, UsuarioAcessoRepository>();
            services.AddScoped<IAmigoRepository, AmigoRepository>();
            services.AddScoped<ICalculoHistoricoLogRepository, CalculoHistoricoLogRepository>();
            services.AddScoped<DemoContext>();
        }
    }
}
