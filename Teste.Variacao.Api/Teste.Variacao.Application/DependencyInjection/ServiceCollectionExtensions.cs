using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Reflection;
using Teste.Variacao.Application.Configuration;
using Teste.Variacao.Application.Interfaces.Queries;
using Teste.Variacao.Application.Queries;
using Teste.Variacao.Application.Refit;

namespace Teste.Variacao.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }

        public static IServiceCollection AddQueryServices(this IServiceCollection services)
        {
            services.AddScoped<IVariacaoAtivoQueryService, VariacaoAtivoQueryService>();
            return services;
        }

        public static IServiceCollection AddRefit(this IServiceCollection services, IConfiguration configuration)
        {
            var financeYahooConfiguration = configuration.GetSection(nameof(FinanceYahooConfiguration)).Get<FinanceYahooConfiguration>();
            services.AddSingleton(financeYahooConfiguration);

            services.AddRefitClient<IFinanceYahooRefitService>()
               .ConfigureHttpClient(c => c.BaseAddress = new Uri(financeYahooConfiguration.Url));
            return services;
        }
    }
}