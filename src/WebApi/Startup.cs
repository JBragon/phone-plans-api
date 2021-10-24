using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using FluentValidation.AspNetCore;
using JBragon.DataAccess.Context;
using JBragon.WebApi.Configuration;
using JBragon.WebApi.Extensions;

namespace JBragon.WebApi
{
    internal class Startup
    {
        public IConfiguration Configuration;
        public Startup(IWebHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MainContext>(options => options.UseMySql(Environment.GetEnvironmentVariable("CONNECTION_STRING")))
                .AddUnitOfWork<MainContext>();

            //services.AddIdentityConfig(Configuration);

            services.AddSwaggerConfig();
            
            services.AddAutoMapper(typeof(Startup));

            services.RegisterMapper();

            services.ResolveDependencies();

            services.AddApiConfig(Configuration);

            services.AddMvcCore().AddFluentValidation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppSettings appSettings)
        {
            app.UseApiConfig(env);

            app.UseSwaggerConfig(appSettings);
        }
    }
}
