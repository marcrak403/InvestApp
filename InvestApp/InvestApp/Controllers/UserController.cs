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
        public async Task<ActionResult<string?>> LoginUser(string mail, string password)
        {
            var token = await _userRepository.GenerateToken(mail, password);
            if (token == null)
                return BadRequest("Invalid username or password");
            return Ok(token);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<User>> GetUserById([FromRoute] int id)
        {
            return Ok(await _userRepository.GetUserById(id));
        }
    }
}
