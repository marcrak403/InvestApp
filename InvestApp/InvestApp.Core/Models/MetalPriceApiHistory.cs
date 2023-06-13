namespace InvestApp.Core.Models
{
    public class MetalPriceApiHistory : MetalHistory
    {
        public bool success { get; set; }
        public string Base { get; set; } = string.Empty;
        public string start_date {  get; set; }
        public string end_date { get; set;}
        public IDictionary<string, IDictionary<string , double>> Rates { get; set; }

    }
}
