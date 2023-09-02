using EduRate.Api.Interfaces;
using EduRate.Api.Services;
using Microsoft.AspNetCore.Mvc;
using EduRate.Api.Models;

namespace EduRate.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var result = _userService.Register(user);
            if (result)
                return Ok();
            return BadRequest("Registration failed.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var token = _userService.Authenticate(request);
            if (token == null)
                return Unauthorized();
            return Ok(new { Token = token });
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            // Logic for logout can go here
            return Ok("Logged out successfully.");
        }

        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            // Logic for fetching user profile can go here
            return Ok("User profile information.");
        }

        [HttpPut("profile")]
        public IActionResult UpdateProfile([FromBody] User user)
        {
            // Logic for updating user profile can go here
            return Ok("Profile updated successfully.");
        }
    }
}