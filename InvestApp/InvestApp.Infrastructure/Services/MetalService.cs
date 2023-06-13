using InvestApp.Core.Constants;
using InvestApp.Core.Models;
using System.Collections;
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
                case Metals.XPT:
                case Metals.XAG:
                case Metals.XPD:
                    HttpResponseMessage responseOther =
                        await client
                            .GetAsync($"https://api.metalpriceapi.com/v1/timeframe?api_key=ebcca32bbd82a461956c594e82d13a87&start_date={fromDate.Date.ToString("yyyy-MM-dd")}&end_date={toDate.Date.ToString("yyyy-MM-dd")}&base=USD&currencies={metal}");

                    string responseStringOther = await responseOther.Content.ReadAsStringAsync();
                    MetalPriceApiHistory resultOther = JsonSerializer.Deserialize<MetalPriceApiHistory>(responseStringOther, options);
                    ICollection<MetalPriceApiHistory> returnedList = new List<MetalPriceApiHistory>();
                    returnedList.Add(resultOther);
                    return returnedList;
            }

            return new List<MetalHistory>();
        }
    }
}
