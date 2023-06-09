using AutoMapper;
using InvestApp.DataAccess.Dtos;
using InvestApp.DataAccess.Entities;

namespace InvestApp.DataAccess.Repositories
{
    public class CurrencyInvestmentRepo : ICurrencyInvestmentRepo
    {
        private readonly InvestAppDbContext _context;
        private readonly IMapper _mapper;

        public CurrencyInvestmentRepo(InvestAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddCurrencyInvestment(AddCurrencyInvestmentDto addCurrencyInvestmentDto)
        {
            if (addCurrencyInvestmentDto != null)
            {
                _context.CurrencyInvestments.Add(_mapper.Map<CurrencyInvestment>(addCurrencyInvestmentDto));
                await _context.SaveChangesAsync();
            }
        }
    }
}
