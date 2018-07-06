using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using Demo.APIDistancia.Domain.Entities;
using Demo.APIDistancia.Domain.ValueObjects;
using Microsoft.Extensions.Logging;
using GlobalExceptionHandler.WebApi;
using Newtonsoft.Json;
using System.Threading.Tasks;
using MediatR;
using Demo.APIDistancia.Application.Interfaces.Services;
using Demo.APIDistancia.Application.Services;
using Demo.APIDistancia.Domain.Interfaces.Repositories;
using Demo.APIDistancia.Repository.Repository;
using Demo.APIDistancia.IoC;
using Demo.APIDistancia.Application.DTO;

namespace Demo.APIDistancia
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<UsuarioAcesso>();
            services.AddTransient<AmigoDTO>();
            services.AddTransient<Amigo>();
            services.AddTransient<CalculoHistoricoLog>();

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfig = new TokenConfig();
            new ConfigureFromConfigurationOptions<TokenConfig>(
                Configuration.GetSection("TokenConfig"))
                    .Configure(tokenConfig);
            services.AddSingleton(tokenConfig);


            services.AddMediatR(typeof(Startup));


            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfig.Audiencia;
                paramsValidation.ValidIssuer = tokenConfig.Emissor;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddMvc();


            services.AddSingleton<IUsuarioAcessoService, UsuarioAcessoService>();
            services.AddSingleton<IAmigoService, AmigoService>();
            services.AddSingleton<ICalculoHistoricoLogService, CalculoHistoricoLogService>();

            services.AddSingleton<IUsuarioAcessoRepository, UsuarioAcessoRepository>();
            services.AddSingleton<IAmigoRepository, AmigoRepository>();
            services.AddSingleton<ICalculoHistoricoLogRepository, CalculoHistoricoLogRepository>();

            Container.RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole();

            app.UseAuthentication();
            UseExceptionHandling(app, loggerFactory);


            app.UseMvc();
        }

        private static void UseExceptionHandling(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler().WithConventions(config =>
            {
                config.ContentType = "application/json";
                config.MessageFormatter(s => JsonConvert.SerializeObject(new
                {
                    
                    Message = "An error occurred whilst processing your request. " + (s.Message != null ? s.Message.ToString() : String.Empty)
                }));

                config.OnError((exception, httpContext) =>
                {
                    var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
                    logger.LogError(exception, exception.Message);
                    return Task.CompletedTask;
                });
            });
        }
    }
}
