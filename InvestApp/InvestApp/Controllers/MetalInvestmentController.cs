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
    public class MetalInvestmentController : ControllerBase
    { 
        private readonly IMetalInvestmentRepo _metalInvestmentRepo;
        private readonly IMetalService _metalService;

        public MetalInvestmentController(IMetalInvestmentRepo metalInvestmentRepo
            ,IMetalService metalService)
        {
            _metalInvestmentRepo = metalInvestmentRepo;
            _metalService = metalService;
        }

        [HttpPost("AddMetalInvestment")]
        public async Task<IActionResult> AddMetalInvestment(AddMetalInvestmentDto addMetalInvestmentDto)
        {
            await _metalInvestmentRepo.AddMetalInvestment(addMetalInvestmentDto);
            return Ok();
        }

        [HttpGet("GetHistoryForMetal/{metal}/{fromDate}/{toDate}")]
        public async Task<ActionResult<IEnumerable<MetalHistory>>> GetHistoryForMetal(
            [FromRoute] Metals metal, [FromRoute] DateTime fromDate, [FromRoute] DateTime toDate)
        {
            return Ok(await _metalService.GetMetalHistory(metal, fromDate, toDate));
        }
    }
}
