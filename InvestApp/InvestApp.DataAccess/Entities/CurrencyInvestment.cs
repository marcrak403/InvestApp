using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using InvestApp.Core.Constants;

namespace InvestApp.DataAccess.Entities
{
    public class CurrencyInvestment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public Currencies CurrencyType { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public decimal ExchangeRate { get; set; }
        public virtual User AssignedTo { get; set; }
        public int AssignedToId { get; set; }
    }
}
