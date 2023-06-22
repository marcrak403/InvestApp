using AutoMapper;
using InvestApp.DataAccess.Dtos;
using InvestApp.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InvestApp.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly InvestAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authentication;


        public UserRepository(InvestAppDbContext context, IMapper mapper, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        { 
            _context = context;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _authentication = authenticationSettings;
        }

        public Task<User?> GetUserById(int id)
        {
            return _context.Users.Include(p => p.CurrencyInvestments)
                .Include(p => p.MetalInvestments)
                .Include(p => p.TotalAmountOfCurrencies)
                .Include(p => p.TotalAmountOfMetals)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task RegisterUser(CreateUserDto createUserDto)
        {
            if (createUserDto != null)
            {
                User user = _mapper.Map<User>(createUserDto);
                user.Password = _passwordHasher.HashPassword(user, createUserDto.Password);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string?> GenerateToken(string mail, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == mail);
            if (user == null)
                return null;

            var check = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (check == PasswordVerificationResult.Failed)
                return null;

            var claims = new List<Claim>()
            {
                new Claim("ID", user.Id.ToString()),
                new Claim("Name", user.Name),
                new Claim("Surname", user.Surname),
                new Claim("Email", user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authentication.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(_authentication.DurationInMinutes);

            var token = new JwtSecurityToken(_authentication.JwtIssuer,
               _authentication.JwtIssuer, claims, expires: expires, signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
