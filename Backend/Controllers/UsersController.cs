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
            try
            {
                return Ok(await _usersService.LoginAsync(username, password));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password, string email)
        {
            try
            {
                return Ok(await _usersService.RegisterAsync(username, password, email));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(string username, string email)
        {
            try
            {
                return Ok(await _usersService.UpdateAsync(username, email));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("changepassword")]
        public async Task<IActionResult> Update(string username, string oldPassword, string newPassword)
        {
            try
            {
                return Ok(await _usersService.ChangePasswordAsync(username,oldPassword,newPassword));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
