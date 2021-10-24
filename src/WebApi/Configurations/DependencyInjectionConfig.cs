using FluentValidation;
using JBragon.Business.Interfaces;
using JBragon.Business.Services;
using JBragon.Models.Mapper.Request;
using JBragon.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace JBragon.WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //Infrastructure
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Services
            services.AddScoped<IPhonePlanService, PhonePlanService>();
            services.AddScoped<IDDDService, DDDService>();
            services.AddScoped<IPhonePlanTypeService, PhonePlanTypeService>();
            services.AddScoped<ITelephoneOperatorService, TelephoneOperatorService>();

            //Resources
            services.AddTransient<ErrorResource>();

            //Fluent Validation
            services.AddTransient<IValidator<PhonePlanPost>, PhonePlanPostValidation>();

            return services;
        }
    }
}
