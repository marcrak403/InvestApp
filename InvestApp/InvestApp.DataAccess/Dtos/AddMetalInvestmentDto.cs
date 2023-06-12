using InvestApp.Core.Constants;

namespace InvestApp.DataAccess.Dtos
{
    public class AddMetalInvestmentDto
    {
        public DateTime PurchaseDate { get; set; }
        public Metals MetalType { get; set; }
        public int Amount { get; set; }
        public decimal ExchangeRate { get; set; }
        public int AssignedToId { get; set; }
    }
}
