using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EwanHolding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermsAndConditionsController : ControllerBase
    {
        private readonly ITermsAndConditionsService _service;
        public TermsAndConditionsController(ITermsAndConditionsService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var terms = await _service.GetAllAsync();
            return Ok(terms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var terms = await _service.GetByIdAsync(id);
            return Ok(terms);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> Create(CreateTermsAndConditionsDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> Update(int id, UpdateTermsAndConditionsDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch.");
            await _service.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}