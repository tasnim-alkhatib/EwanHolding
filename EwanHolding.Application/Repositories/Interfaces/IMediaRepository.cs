using EwanHolding.Domain.Entities;
using EwanHolding.Domain.Enums;

namespace EwanHolding.Application.Repositories.Interfaces
{
    public interface IMediaRepository
    {
        Task<IEnumerable<Media>> GetByEntityAsync(int entityId, MediaEntityType entityType);
        Task<Media> GetByIdAsync(int id);
        void Create(Media media);
        void Delete(Media media);
    }
}