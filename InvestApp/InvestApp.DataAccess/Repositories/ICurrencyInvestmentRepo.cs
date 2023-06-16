using InvestApp.Core.Constants;
using InvestApp.DataAccess.Dtos;

namespace InvestApp.DataAccess.Repositories
{
    public interface ICurrencyInvestmentRepo
    {
        Task AddCurrencyInvestment(AddCurrencyInvestmentDto addCurrencyInvestmentDto);
        Task SellCurrency(int userId, Currencies currency, int amount);
    }
}
