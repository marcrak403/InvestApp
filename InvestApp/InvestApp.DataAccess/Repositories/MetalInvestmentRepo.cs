
using AutoMapper;
using InvestApp.DataAccess.Dtos;
using InvestApp.DataAccess.Entities;

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
            await _context.AddAsync(_mapper.Map<MetalInvestment>(addMetalInvestmentDto));
            await _context.SaveChangesAsync();
        }
    }
}
