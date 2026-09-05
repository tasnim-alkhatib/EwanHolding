using EwanHolding.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using EwanHolding.Application.Services.Interfaces;

namespace EwanHolding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AuthController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _adminService.LoginAsync(loginDto);
            return Ok(result);
        }
    }
}
