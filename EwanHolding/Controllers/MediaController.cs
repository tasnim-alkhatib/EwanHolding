using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using EwanHolding.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EwanHolding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;
        public MediaController(IMediaService mediaService) => _mediaService = mediaService;

        [HttpGet("entity/{entityId}/{entityType}")]
        public async Task<IActionResult> GetByEntity(int entityId, MediaEntityType entityType)
        {
            var media = await _mediaService.GetByEntityAsync(entityId, entityType);
            return Ok(media);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> Create(CreateMediaDto dto)
        {
            await _mediaService.CreateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediaService.DeleteAsync(id);
            return Ok();
        }
    }
}