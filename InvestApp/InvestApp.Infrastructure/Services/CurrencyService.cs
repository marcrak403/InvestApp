using InvestApp.Core.Constants;
using InvestApp.Core.Models;
using System.Text.Json;

namespace InvestApp.Infrastructure.Services
{
    public class CurrencyService : ICurrencyService
    {
        private static readonly HttpClient client = new HttpClient();

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };


        public async Task<CurrencyHistory> GetCurrencyHistory(Currencies currency, DateTime fromDate,
            DateTime toDate)
        {
            HttpResponseMessage response =
                await client
                    .GetAsync($"https://api.nbp.pl/api/exchangerates/rates/a/{currency}/{fromDate.Date.ToString("yyyy-MM-dd")}/{toDate.Date.ToString("yyyy-MM-dd")}/?format=json");

            string responseString = await response.Content.ReadAsStringAsync();
            CurrencyHistory result = JsonSerializer.Deserialize<CurrencyHistory>(responseString, options);

            return result;
        }
    }
}
