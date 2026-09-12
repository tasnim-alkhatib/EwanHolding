using EwanHolding.Application.DTOs;
using EwanHolding.Domain.Enums;

namespace EwanHolding.Application.Services.Interfaces
{
    public interface IMediaService
    {
        Task<IEnumerable<MediaResponseDto>> GetByEntityAsync(int entityId, MediaEntityType entityType);
        Task CreateAsync(CreateMediaDto dto);
        Task DeleteAsync(int id);
    }
}