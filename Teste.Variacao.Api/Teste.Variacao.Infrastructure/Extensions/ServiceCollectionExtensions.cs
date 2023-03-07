using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Teste.Variacao.Domain.Repositories;
using Teste.Variacao.Infrastructure.DbContexts;
using Teste.Variacao.Infrastructure.Interfaces;
using Teste.Variacao.Infrastructure.Repositories;

namespace Teste.Variacao.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
            AddDbContext(services, configuration);
        }        

        public static void AddRepositories(this IServiceCollection services)
        {            
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));            
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IVariacaoAtivoRepository, VariacaoAtivoRepository>();
        }

        [ExcludeFromCodeCoverage]
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseLazyLoadingProxies()
                   .UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(
                     options => options.UseLazyLoadingProxies()
                        .UseNpgsql(configuration.GetConnectionString("ApplicationConnection"),
                     b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                 );
            }
        }
    }
}