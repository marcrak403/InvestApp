namespace InvestApp.Core.Models
{
    public abstract class MetalHistory
    {
    }

    public class SilverHistory : MetalHistory
    {
        public DateTime Data { get; set; }
        public double Cena { get; set; }
    }
}
