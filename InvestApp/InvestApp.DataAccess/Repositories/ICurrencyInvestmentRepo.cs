using InvestApp.DataAccess.Dtos;

namespace InvestApp.DataAccess.Repositories
{
    public interface ICurrencyInvestmentRepo
    {
        Task AddCurrencyInvestment(AddCurrencyInvestmentDto addCurrencyInvestmentDto);
    }
}
