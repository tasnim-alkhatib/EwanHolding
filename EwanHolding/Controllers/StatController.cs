using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Implementation;
using EwanHolding.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EwanHolding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        private readonly IStatService _statService;
        public StatController(IStatService statService) => _statService = statService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stats = await _statService.GetAllAsync();
            return Ok(stats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Invalid stat id, Id must be a positive integer.");

            var stat = await _statService.GetByIdAsync(id);
            return Ok(stat);
        }

        [HttpPost]
        //[Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> Create(CreateStatDto dto)
        {
            await _statService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> Update(int id, UpdateStatDto dto)
        {
            if (id != dto.Id) return BadRequest("Id mismatch.");

            await _statService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> Delete(int id)
        {
            await _statService.DeleteAsync(id);
            return Ok();
        }
    }
}
