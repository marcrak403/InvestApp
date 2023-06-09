using InvestApp.Core.Models;
using InvestApp.DataAccess.Dtos;
using InvestApp.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InvestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyInvestmentController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly ICurrencyInvestmentRepo _currencyInvestmentRepo;

        public CurrencyInvestmentController(ICurrencyInvestmentRepo currencyInvestmentRepo)
        {
            _currencyInvestmentRepo = currencyInvestmentRepo;
        }

        [HttpPost("AddCurrencyInvestment")]
        public async Task<IActionResult> AddCurrencyInvestment(AddCurrencyInvestmentDto addCurrencyInvestmentDto) 
        {
            await _currencyInvestmentRepo.AddCurrencyInvestment(addCurrencyInvestmentDto);
            return Ok();
        }

        [HttpGet("GetHistoryForCurrency")]
        public async Task<IActionResult> GetHistoryForCurrency()
        {
            //To do it doesnt work
            var response = await client.GetAsync("https://api.nbp.pl/api/exchangerates/rates/a/gbp/2012-01-01/2012-01-31/?format=json");

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IEnumerable<CurrencyHistory>>(responseString);


            return Ok();
        }
    }
}
