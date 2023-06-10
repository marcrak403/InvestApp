using InvestApp.Core.Constants;
using InvestApp.Core.Models;
using InvestApp.DataAccess.Dtos;
using InvestApp.DataAccess.Repositories;
using InvestApp.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyInvestmentController : ControllerBase
    {
        private readonly ICurrencyInvestmentRepo _currencyInvestmentRepo;
        private readonly ICurrencyService _currencyService;

        public CurrencyInvestmentController(ICurrencyInvestmentRepo currencyInvestmentRepo, 
            ICurrencyService currencyService)
        {
            _currencyInvestmentRepo = currencyInvestmentRepo;
            _currencyService = currencyService;
        }

        [HttpPost("AddCurrencyInvestment")]
        public async Task<IActionResult> AddCurrencyInvestment(AddCurrencyInvestmentDto addCurrencyInvestmentDto) 
        {
            await _currencyInvestmentRepo.AddCurrencyInvestment(addCurrencyInvestmentDto);
            return Ok();
        }

        [HttpGet("GetHistoryForCurrency/{currency}/{fromDate}/{toDate}")]
        public async Task<ActionResult<CurrencyHistory>> GetHistoryForCurrency(
            [FromRoute] Currencies currency, [FromRoute] DateTime fromDate, [FromRoute] DateTime toDate)
        {
            return Ok(await _currencyService.GetCurrencyHistory(currency, fromDate, toDate));
        }
    }
}
