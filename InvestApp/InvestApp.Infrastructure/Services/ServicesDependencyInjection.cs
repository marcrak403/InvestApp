using Microsoft.Extensions.DependencyInjection;

namespace InvestApp.Infrastructure.Services
{
    public static class ServicesDependencyInjection
    {
        public static void AddInvestServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IMetalService, MetalService>();
        }
    }
}
