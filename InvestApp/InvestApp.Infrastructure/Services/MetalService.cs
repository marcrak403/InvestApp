using InvestApp.Core.Constants;
using InvestApp.Core.Models;
using System.Text.Json;

namespace InvestApp.Infrastructure.Services
{
    public class MetalService : IMetalService
    {
        private static readonly HttpClient client = new HttpClient();

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<IEnumerable<MetalHistory>> GetMetalHistory(Metals metal, DateTime fromDate, DateTime toDate)
        {
            switch(metal)
            {
                case Metals.Gold:
                    HttpResponseMessage response =
                        await client
                            .GetAsync($"https://api.nbp.pl/api/cenyzlota/{fromDate.Date.ToString("yyyy-MM-dd")}/{toDate.Date.ToString("yyyy-MM-dd")}/?format=json");

                    string responseString = await response.Content.ReadAsStringAsync();
                    IEnumerable<GoldHistory> result = JsonSerializer.Deserialize<IEnumerable<GoldHistory>>(responseString, options);
                    return result;
            }

            return new List<MetalHistory>();
        }
    }
}
