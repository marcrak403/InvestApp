using InvestApp.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InvestApp.DataAccess
{
    public static class DataAccessDependencyInjection
    {
        public static void AddSql(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<InvestAppDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICurrencyInvestmentRepo, CurrencyInvestmentRepo>();
            services.AddScoped<IMetalInvestmentRepo, MetalInvestmentRepo>();
        }
    }
}
