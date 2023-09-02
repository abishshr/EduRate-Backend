using EduRate.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EduRate.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

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

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            string authHeader = HttpContext.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length).Trim();
                var user = _userService.Logout(1, token); // replace 1 with actual userId from your claims or database
                if (user != null)
                {
                    return Ok("Logged out successfully.");
                }
            }
            return BadRequest("Could not log out.");
        }

        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            // Extract user ID from JWT token
            var token = HttpContext.Request.Headers["Authorization"].ToString().Split(" ").Last();
            var jwtToken = new JwtSecurityToken(token);
            var userIdClaim = jwtToken.Claims.First(claim => claim.Type == "name");
            if (int.TryParse(userIdClaim.Value, out int userId))
            {
                var user = _userService.GetProfile(userId);
                if (user != null)
                {
                    return Ok(user);
                }
            }
            return NotFound("User profile not found.");
        }

        [HttpPut("profile")]
        public IActionResult UpdateProfile([FromBody] User user)
        {
            // Logic for updating user profile can go here
            return Ok("Profile updated successfully.");
        }
    }
}
