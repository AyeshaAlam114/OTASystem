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
            var userJson = await _userService.Authenticate(userLogin.Username, userLogin.Password);
            if (userJson == null)
                return Unauthorized(new { Message = "Invalid credentials" });

            return Ok(userJson);
        }
    }
}
