using AutoMapper;
using InvestApp.DataAccess.Dtos;
using InvestApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestApp.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly InvestAppDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(InvestAppDbContext context, IMapper mapper)
        { 
            _context = context;
            _mapper = mapper;
        }

        public Task<User?> GetUserById(int id)
        {
            return _context.Users.Include(p => p.CurrencyInvestments)
                .Include(p => p.MetalInvestments)
                .Include(p => p.TotalAmountOfCurrencies)
                .Include(p => p.TotalAmountOfMetals)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<User?> LoginUser(string mail, string password)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(p => p.Email == mail && p.Password == password);
            return user == null ? null : user;
        }

        public async Task RegisterUser(CreateUserDto createUserDto)
        {
            if (createUserDto != null)
            {
                _context.Users.Add(_mapper.Map<User>(createUserDto));
                await _context.SaveChangesAsync();
            }
        }
    }
}
