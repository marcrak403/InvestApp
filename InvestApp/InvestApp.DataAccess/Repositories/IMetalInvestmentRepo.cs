using InvestApp.DataAccess.Dtos;

namespace InvestApp.DataAccess.Repositories
{
    public interface IMetalInvestmentRepo
    {
        Task AddMetalInvestment(AddMetalInvestmentDto addMetalInvestmentDto);
    }
}
