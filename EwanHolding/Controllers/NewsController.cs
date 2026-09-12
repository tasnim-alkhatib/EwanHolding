using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EwanHolding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService) => _newsService = newsService;

        [HttpGet]
        [Authorize(Roles = "SuperAdmin,ContentManager,Editor")]
        public async Task<IActionResult> GetAll()
        {
            var news = await _newsService.GetAllAsync();
            return Ok(news);
        }

        [HttpGet("published")]
        public async Task<IActionResult> GetPublished()
        {
            var news = await _newsService.GetPublishedAsync();
            return Ok(news);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var news = await _newsService.GetByIdAsync(id);
            return Ok(news);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> Create(CreateNewsDto dto)
        {
            await _newsService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> Update(int id, UpdateNewsDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch.");
            await _newsService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> Delete(int id)
        {
            await _newsService.DeleteAsync(id);
            return Ok();
        }
    }
}