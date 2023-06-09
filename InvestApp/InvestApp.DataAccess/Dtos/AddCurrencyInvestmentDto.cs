using InvestApp.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace InvestApp.DataAccess.Dtos
{
    public class AddCurrencyInvestmentDto
    {
        public DateTime PurchaseDate { get; set; }
        public Currencies CurrencyType { get; set; }
        public int Amount { get; set; }
        public decimal ExchangeRate { get; set; }
        public int AssignedToId { get; set; }

    }
}
