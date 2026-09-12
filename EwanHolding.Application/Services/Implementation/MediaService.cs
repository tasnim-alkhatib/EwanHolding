using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using EwanHolding.Application.UnitOfWork;
using EwanHolding.Domain.Entities;
using EwanHolding.Domain.Enums;

namespace EwanHolding.Application.Services.Implementation
{
    public class MediaService : IMediaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MediaService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<MediaResponseDto>> GetByEntityAsync(int entityId, MediaEntityType entityType)
        {
            var media = await _unitOfWork.Media.GetByEntityAsync(entityId, entityType);
            return media.Select(m => new MediaResponseDto
            {
                Id = m.Id,
                Url = m.Url,
                EntityType = m.EntityType,
                Type = m.Type,
                DisplayOrder = m.DisplayOrder
            });
        }

        public async Task CreateAsync(CreateMediaDto dto)
        {
            var media = new Media
            {
                Url = dto.Url,
                EntityId = dto.EntityId,
                EntityType = dto.EntityType,
                Type = dto.Type,
                DisplayOrder = dto.DisplayOrder
            };

            _unitOfWork.Media.Create(media);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var media = await _unitOfWork.Media.GetByIdAsync(id);
            if (media == null) throw new Exception($"Media with ID {id} not found.");

            _unitOfWork.Media.Delete(media);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}