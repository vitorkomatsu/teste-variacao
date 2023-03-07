using Microsoft.AspNetCore.Builder;
using System.Diagnostics.CodeAnalysis;

namespace Teste.Variacao.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("swagger/v1/swagger.json", "Teste.Variacao.Api");
                options.RoutePrefix = "";
                options.EnableFilter();
                options.DisplayRequestDuration();
            });
        }
    }
}