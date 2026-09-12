using EwanHolding.Application.Repositories.Interfaces;
using EwanHolding.Domain.Entities;
using EwanHolding.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EwanHolding.Application.Repositories.Implementation
{
    public class TermsAndConditionsRepository : ITermsAndConditionsRepository
    {
        private readonly EwanHoldingDbContext _context;
        public TermsAndConditionsRepository(EwanHoldingDbContext context) => _context = context;

        public async Task<IEnumerable<TermsAndConditions>> GetAllAsync()
            => await _context.TermsAndConditions.AsNoTracking().ToListAsync();

        public async Task<TermsAndConditions> GetByIdAsync(int id)
            => await _context.TermsAndConditions.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

        public void Create(TermsAndConditions terms) => _context.TermsAndConditions.Add(terms);
        public void Update(TermsAndConditions terms) => _context.TermsAndConditions.Update(terms);
        public void Delete(TermsAndConditions terms) => _context.TermsAndConditions.Remove(terms);
    }
}