using InvestApp.DataAccess.Dtos;
using InvestApp.DataAccess.Entities;

namespace InvestApp.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task RegisterUser(CreateUserDto createUserDto);
        Task<User?> LoginUser(string mail, string password);

        Task<User?> GetUserById(int id);
    }
}
