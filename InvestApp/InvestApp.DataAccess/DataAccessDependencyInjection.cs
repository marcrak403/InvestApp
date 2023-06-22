using FluentValidation;
using InvestApp.DataAccess.Dtos;
using InvestApp.DataAccess.Entities;
using InvestApp.DataAccess.Repositories;
using InvestApp.DataAccess.Validators;
using Microsoft.AspNetCore.Identity;
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
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IValidator<CreateUserDto>, RegisterValidator>();
        }
    }
}
