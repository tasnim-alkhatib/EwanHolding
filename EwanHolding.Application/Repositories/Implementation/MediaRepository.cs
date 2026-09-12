using EwanHolding.Application.Repositories.Interfaces;
using EwanHolding.Domain.Entities;
using EwanHolding.Domain.Enums;
using EwanHolding.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EwanHolding.Application.Repositories.Implementation
{
    public class MediaRepository : IMediaRepository
    {
        private readonly EwanHoldingDbContext _context;
        public MediaRepository(EwanHoldingDbContext context) => _context = context;

        public async Task<IEnumerable<Media>> GetByEntityAsync(int entityId, MediaEntityType entityType)
            => await _context.Medias.AsNoTracking()
                .Where(m => m.EntityId == entityId && m.EntityType == entityType)
                .OrderBy(m => m.DisplayOrder)
                .ToListAsync();

        public async Task<Media> GetByIdAsync(int id)
            => await _context.Medias.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

        public void Create(Media media) => _context.Medias.Add(media);
        public void Delete(Media media) => _context.Medias.Remove(media);
    }
}