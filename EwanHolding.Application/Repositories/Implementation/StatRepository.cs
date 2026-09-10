using EwanHolding.Application.Repositories.Interfaces;
using EwanHolding.Domain.Entities;
using EwanHolding.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EwanHolding.Application.Repositories.Implementation
{
    public class StatRepository : IStatRepository
    {
        private readonly EwanHoldingDbContext _context;
        public StatRepository(EwanHoldingDbContext context) => _context = context;

        public async Task<IEnumerable<Stat>> GetAllAsync() 
            => await _context.Stats.AsNoTracking().ToListAsync();

        public async Task<Stat> GetByIdAsync(int id) 
            => await _context.Stats.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);

        public async Task<Stat> GetByLabelAsync(string label) 
            => await _context.Stats.AsNoTracking().FirstOrDefaultAsync(s => s.Label_En == label || s.Label_Ar == label);

        public void Create(Stat stat) => _context.Stats.Add(stat);
        public void Update(Stat stat) => _context.Stats.Update(stat);
        public void Delete(Stat stat) => _context.Stats.Remove(stat);
    }
}
