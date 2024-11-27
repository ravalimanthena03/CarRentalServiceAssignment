using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRentalServiceAssignment.Models;
using CarRentalServiceAssignment.Services;
namespace CarRentalServiceAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService) => _userService = userService;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(User user)
        {
            await _userService.RegisterUser(user);
            return Ok("User registered successfully!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var token = await _userService.AuthenticateUser(email, password);
            if (token == null)
                return Unauthorized("Invalid email or password.");

            return Ok(new { Token = token });
        }
    }
}
