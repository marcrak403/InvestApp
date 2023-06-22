using InvestApp.DataAccess.Dtos;
using InvestApp.DataAccess.Entities;

namespace InvestApp.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task RegisterUser(CreateUserDto createUserDto);
        Task<string?> GenerateToken(string mail, string password);
        Task<User?> GetUserById(int id);
    }
}
