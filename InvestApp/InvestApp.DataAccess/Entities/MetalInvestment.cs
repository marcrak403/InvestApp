
using InvestApp.Core.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InvestApp.DataAccess.Entities
{
    public class MetalInvestment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public Metals MetalType { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public decimal ExchangeRate { get; set; }
        public virtual User AssignedTo { get; set; }
        public int AssignedToId { get; set; }
    }
}
