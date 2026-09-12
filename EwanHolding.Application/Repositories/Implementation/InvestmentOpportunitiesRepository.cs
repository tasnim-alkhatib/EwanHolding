using EwanHolding.Application.Repositories.Interfaces;
using EwanHolding.Domain.Entities;
using EwanHolding.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EwanHolding.Application.Repositories.Implementation
{
    public class InvestmentOpportunitiesRepository : IInvestmentOpportunitiesRepository
    {
        private readonly EwanHoldingDbContext _context;
        public InvestmentOpportunitiesRepository(EwanHoldingDbContext context) => _context = context;

        public async Task<IEnumerable<InvestmentOpportunities>> GetAllAsync()
            => await _context.InvestmentOpportunities.AsNoTracking().ToListAsync();

        public async Task<InvestmentOpportunities> GetByIdAsync(int id)
            => await _context.InvestmentOpportunities.AsNoTracking().FirstOrDefaultAsync(cv => cv.Id == id);

        public async Task<InvestmentOpportunities> GetByTitleAsync(string title)
            => await _context.InvestmentOpportunities.AsNoTracking().FirstOrDefaultAsync(cv => cv.Title_En == title || cv.Title_Ar == title);

        public void Create(InvestmentOpportunities investmentOpportunity) => _context.InvestmentOpportunities.Add(investmentOpportunity);
        public void Update(InvestmentOpportunities investmentOpportunity) => _context.InvestmentOpportunities.Update(investmentOpportunity);
        public void Delete(InvestmentOpportunities investmentOpportunity) => _context.InvestmentOpportunities.Remove(investmentOpportunity);
    }
}
