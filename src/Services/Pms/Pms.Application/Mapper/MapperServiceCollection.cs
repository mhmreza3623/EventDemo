using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Pms.Application.Mapper
{
    public static class MapperServiceCollection
    {
        public static void AddApplicationMapperProfile(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
