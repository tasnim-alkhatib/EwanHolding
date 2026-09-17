using EwanHolding.Api.Services;
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
        private readonly IFileStorageService _fileStorageService;
        public MediaController(IMediaService mediaService, IFileStorageService fileStorageService)
        {
            _mediaService = mediaService;
            _fileStorageService = fileStorageService;
        }

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

        /// <summary>
        /// Uploads an actual image/PDF file (multipart/form-data) and creates its Media record in one call,
        /// so the admin dashboard doesn't need a URL up front - it can upload the file directly.
        /// entityType decides the storage sub-folder (company/news/investment) purely for organization on disk.
        /// </summary>
        [HttpPost("upload")]
        [Authorize(Roles = "SuperAdmin,ContentManager")]
        [RequestSizeLimit(5 * 1024 * 1024)]
        public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromForm] int entityId, [FromForm] MediaEntityType entityType, [FromForm] MediaType type, [FromForm] int displayOrder = 0)
        {
            var subFolder = entityType.ToString().ToLowerInvariant();
            var url = await _fileStorageService.SaveFileAsync(file, subFolder);

            var mediaDto = new CreateMediaDto
            {
                Url = url,
                EntityId = entityId,
                EntityType = entityType,
                Type = type,
                DisplayOrder = displayOrder
            };

            await _mediaService.CreateAsync(mediaDto);
            return Ok(new { url });
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