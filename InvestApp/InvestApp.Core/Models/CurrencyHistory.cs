using InvestApp.Core.Constants;

namespace InvestApp.Core.Models
{
    public class CurrencyHistory
    {
        public string Table { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public IEnumerable<CurrencyRates> Rates { get; set; }
    }
}
