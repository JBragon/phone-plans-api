using AutoMapper;
using JBragon.Models;
using JBragon.Models.Mapper.Request;
using JBragon.Models.Mapper.Response;
using Microsoft.Extensions.DependencyInjection;

namespace  JBragon.WebApi.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<PhonePlan, PhonePlanPost>().ReverseMap();
            CreateMap<PhonePlan, PhonePlanPut>().ReverseMap();
            CreateMap<PhonePlan, PhonePlanResponse>().ReverseMap();          
            CreateMap<DDD, DDDResponse>().ReverseMap();          
            CreateMap<PhonePlanType, PhonePlanTypeResponse>().ReverseMap();          
            CreateMap<TelephoneOperator, TelephoneOperatorResponse>().ReverseMap();          
        }
    }

    public static class AutoMapperExtension
    {
        /// <summary>
        /// Registrar AutoMapper
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            mappingConfig.AssertConfigurationIsValid();
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
