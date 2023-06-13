
using AutoMapper;
using InvestApp.DataAccess.Dtos;
using InvestApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestApp.DataAccess.Repositories
{
    public class MetalInvestmentRepo : IMetalInvestmentRepo
    {
        private readonly InvestAppDbContext _context;
        private readonly IMapper _mapper;

        public MetalInvestmentRepo(InvestAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddMetalInvestment(AddMetalInvestmentDto addMetalInvestmentDto)
        {
            await _context.MetalInvestments.AddAsync(_mapper.Map<MetalInvestment>(addMetalInvestmentDto));

            var totalAmount = await _context.TotalAmountOfMetals
                .FirstOrDefaultAsync(p => p.MetalType == addMetalInvestmentDto.MetalType
                && p.AssignedToId == addMetalInvestmentDto.AssignedToId);

            if (totalAmount != null)
            {
                totalAmount.TotalAmount += addMetalInvestmentDto.Amount;
                totalAmount.InvestedMoney += addMetalInvestmentDto.Amount * Convert.ToDouble(addMetalInvestmentDto.ExchangeRate);
            }
            else
            {
                _context.TotalAmountOfMetals.Add(new TotalAmountOfMetal()
                {
                    MetalType = addMetalInvestmentDto.MetalType,
                    TotalAmount = addMetalInvestmentDto.Amount,
                    InvestedMoney = addMetalInvestmentDto.Amount * Convert.ToDouble(addMetalInvestmentDto.ExchangeRate),
                    AssignedToId = addMetalInvestmentDto.AssignedToId
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
