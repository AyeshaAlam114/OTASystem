using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using OTASystem.Services;
using OTASystem.DTOs;

namespace OTASystem.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            var user = await _userService.Authenticate(userLogin.Username, userLogin.Password);

            if (user == null)
                return Unauthorized(new { Message = "Invalid username or password" });

            return Ok(new { Message = "Login successful", User = user.Username });
        }
    }
}
