using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EwanHolding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService) => _serviceService = serviceService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var services = await _serviceService.GetAllAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            if (id <= 0) return BadRequest("Invalid service id, Id must be a positive integer.");

            var service = await _serviceService.GetByIdAsync(id);
            return Ok(service);
        }

        [HttpPost]
        //[Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> Create(CreateServiceDto serviceDto) 
        {
            await _serviceService.CreateAsync(serviceDto);
            return Ok();
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> Update(UpdateServiceDto serviceDto)
        {
            await _serviceService.UpdateAsync(serviceDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceService.DeleteAsync(id);
            return Ok();
        }
    }
}
