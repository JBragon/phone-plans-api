using HealthChecks.UI.Client;
using JBragon.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;

namespace JBragon.WebApi.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = new AppSettings();
            new ConfigureFromConfigurationOptions<AppSettings>(
                configuration.GetSection("AppSettings"))
                    .Configure(appSettings);

            services.AddSingleton(appSettings);

            services.AddCors();

            services.AddLocalization(options => options.ResourcesPath = "");
            //services.Configure<RequestLocalizationOptions>(
            //    options =>
            //    {
            //        var supportedCultures = new List<CultureInfo>
            //        {
            //            new CultureInfo(CultureName.PT_BR),
            //            new CultureInfo(CultureName.EN_US)
            //        };

            //        options.DefaultRequestCulture = new RequestCulture(culture: CultureName.EN_US, uiCulture: CultureName.EN_US);
            //        options.SupportedCultures = supportedCultures;
            //        options.SupportedUICultures = supportedCultures;
            //        options.RequestCultureProviders = new[] { new RouteDataRequestCultureProvider { IndexOfCulture = 1, IndexofUICulture = 1 } };
            //    });

            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            services.AddControllers()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddHealthChecks()
                .AddMySql(Environment.GetEnvironmentVariable("CONNECTION_STRING"), "MySql - Main DB",
                Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Degraded);

            return services;
        }

        public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == Environments.Development)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();                
                app.UseHsts();
            }

            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            var localizedOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizedOptions.Value);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });

            return app;
        }
    }
}
