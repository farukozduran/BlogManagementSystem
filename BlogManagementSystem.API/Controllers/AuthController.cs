using BlogManagementSystem.Application.DTOs.Auth;
using BlogManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto dto)
        {
            var token = await _authService.RegisterAsync(dto);
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var token = await _authService.LoginAsync(dto);
            return Ok(new { token });
        }
    }
}
