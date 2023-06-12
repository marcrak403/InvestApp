using InvestApp.Core.Constants;
using InvestApp.Core.Models;

namespace InvestApp.Infrastructure.Services
{
    public interface IMetalService
    {
        Task<IEnumerable<MetalHistory>> GetMetalHistory(Metals metal, DateTime fromDate, DateTime toDate);

    }
}
