using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EwanHolding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageContentController : ControllerBase
    {
        private readonly IPageContentService _service;
        public PageContentController(IPageContentService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var content = await _service.GetAllAsync();
            return Ok(content);
        }

        [HttpGet("page/{pageName}")]
        public async Task<IActionResult> GetByPageName(string pageName)
        {
            var content = await _service.GetByPageNameAsync(pageName);
            return Ok(content);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> Create(CreatePageContentDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> Update(int id, UpdatePageContentDto dto)
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