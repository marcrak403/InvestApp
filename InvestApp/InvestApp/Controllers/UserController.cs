using InvestApp.DataAccess.Dtos;
using InvestApp.DataAccess.Entities;
using InvestApp.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InvestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserDto createUserDto)
        {
           await _userRepository.RegisterUser(createUserDto);
           return Ok();
        }

        [HttpGet("LoginUser/{mail}/{password}")]
        public async Task<ActionResult<User?>> LoginUser(string mail, string password)
        {
            return Ok(await _userRepository.LoginUser(mail, password));
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<User>> GetUserById([FromRoute] int id)
        {
            return Ok(await _userRepository.GetUserById(id));
        }
    }
}
