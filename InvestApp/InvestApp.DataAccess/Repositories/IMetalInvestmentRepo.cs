using InvestApp.Core.Constants;
using InvestApp.DataAccess.Dtos;

namespace InvestApp.DataAccess.Repositories
{
    public interface IMetalInvestmentRepo
    {
        Task AddMetalInvestment(AddMetalInvestmentDto addMetalInvestmentDto);
        Task SellMetalInvestment(int userId, Metals metal, int amount);
    }
}
