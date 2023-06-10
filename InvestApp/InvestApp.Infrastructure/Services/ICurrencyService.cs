using InvestApp.Core.Constants;
using InvestApp.Core.Models;

namespace InvestApp.Infrastructure.Services
{
    public interface ICurrencyService
    {
        Task<CurrencyHistory> GetCurrencyHistory(Currencies currency, DateTime fromDate, DateTime toDate);
    }
}
