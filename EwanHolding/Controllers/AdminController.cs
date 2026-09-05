using Microsoft.AspNetCore.Mvc;
using EwanHolding.Application.Services.Interfaces;
using EwanHolding.Application.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace EwanHolding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var admins = await _adminService.GetAllAsync();
            return Ok(admins);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var admin = await _adminService.GetByIdAsync(id);
            return Ok(admin);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAdminDto adminDto)
        {
            await _adminService.CreateAsync(adminDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateAdminDto adminDto)
        {
            await _adminService.UpdateAsync(adminDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _adminService.DeleteAsync(id);
            return Ok();
        }
    }
}
