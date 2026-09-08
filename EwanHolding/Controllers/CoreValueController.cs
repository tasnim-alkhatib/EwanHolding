using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EwanHolding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "SuperAdmin,ContentManager")]
    public class CoreValueController : ControllerBase
    {
        private readonly ICoreValueService _coreValueService;
        public CoreValueController(ICoreValueService coreValueService) => _coreValueService = coreValueService;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var coreValues = await _coreValueService.GetAllAsync();
            return Ok(coreValues);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var coreValue = await _coreValueService.GetByIdAsync(id);
            return Ok(coreValue);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCoreValueDto dto)
        {
            await _coreValueService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateCoreValueDto dto)
        {
            if (id != dto.Id) return BadRequest("Id mismatch.");

            await _coreValueService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _coreValueService.DeleteAsync(id);
            return Ok();
        }
    }
}
    