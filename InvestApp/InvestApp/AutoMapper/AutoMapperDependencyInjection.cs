using Microsoft.Extensions.Configuration;

namespace InvestApp.AutoMapper
{
    public static class AutoMapperDependencyInjection
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AutoMapper.Configure);
        }
    }
}
