using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;
using Teste.Variacao.Api.Extensions;
using Teste.Variacao.Api.Middleware;
using Teste.Variacao.Infrastructure.DbContexts;
using Teste.Variacao.Application.DependencyInjection;
using Teste.Variacao.Infrastructure.Extensions;

namespace Teste.Variacao.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddValidation();
            services.AddApplicationLayer();
            services.AddRefit(_configuration);
            services.AddPersistenceContexts(_configuration);
            services.AddRepositories();
            services.AddQueryServices();
            services.AddControllers();
            services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();
            services.AddEssentials();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(
                    builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            }

            app.ConfigureSwagger();
            app.UseHttpsRedirection();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
                endpoints.MapHealthChecks("/ready");
            });
        }
    }
}