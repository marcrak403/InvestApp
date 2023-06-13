using InvestApp.Core.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InvestApp.DataAccess.Entities
{
    public class TotalAmountOfMetal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Metals MetalType { get; set; }
        public int TotalAmount { get; set; }
        public double InvestedMoney { get; set; }
        public virtual User AssignedTo { get; set; }
        public int AssignedToId { get; set; }
    }
}
