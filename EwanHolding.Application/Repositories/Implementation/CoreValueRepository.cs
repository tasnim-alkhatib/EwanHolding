using EwanHolding.Application.Repositories.Interfaces;
using EwanHolding.Domain.Entities;
using EwanHolding.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EwanHolding.Application.Repositories.Implementation
{
    public class CoreValueRepository : ICoreValueRepository
    {
        private readonly EwanHoldingDbContext _context;
        public CoreValueRepository(EwanHoldingDbContext context) => _context = context;

        public async Task<IEnumerable<CoreValue>> GetAllAsync()
            => await _context.CoreValues.AsNoTracking().ToListAsync();

        public async Task<CoreValue> GetByIdAsync(int id)
            => await _context.CoreValues.AsNoTracking().FirstOrDefaultAsync(cv => cv.Id == id);

        public async Task<CoreValue> GetByTitleAsync(string title)
            => await _context.CoreValues.AsNoTracking().FirstOrDefaultAsync(cv => cv.Title_En == title || cv.Title_Ar == title);

        public void Create(CoreValue coreValue) => _context.CoreValues.Add(coreValue);
        public void Update(CoreValue coreValue) => _context.CoreValues.Update(coreValue);
        public void Delete(CoreValue coreValue) => _context.CoreValues.Remove(coreValue);
    }
}
