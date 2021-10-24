using JBragon.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace JBragon.WebApi.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Phone Plans API",
                    Version = "v1",
                    Description = "Microsserviço destinado a gerenciamento de planos de telefonia",
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insert the JWT token: Bearer {your token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app, AppSettings appSettings)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "help/{documentName}/docs.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{appSettings.PathApp}/help/v1/docs.json", "Phone Plans API");
                c.RoutePrefix = "help";
            });

            return app;
        }
    }
}
