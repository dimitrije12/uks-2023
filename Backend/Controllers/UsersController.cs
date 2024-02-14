using Backend.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            return Ok(await _usersService.LoginAsync(username, password));
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password, string email)
        {

            return Ok(await _usersService.RegisterAsync(username, password, email));

        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(string username, string email)
        {
           return Ok(await _usersService.UpdateAsync(username, email));
        }
        [HttpPut("changepassword")]
        public async Task<IActionResult> Update(string username, string oldPassword, string newPassword)
        {
            return Ok(await _usersService.ChangePasswordAsync(username, oldPassword, newPassword));
        }
    }
}
