using EwanHolding.Application.Repositories.Interfaces;
using EwanHolding.Domain.Entities;
using EwanHolding.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EwanHolding.Application.Repositories.Implementation
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly EwanHoldingDbContext _context;
        public CompanyRepository(EwanHoldingDbContext context) =>_context = context;
        
        public async Task<IEnumerable<Company>> GetAllAsync()
            => await _context.Companies.AsNoTracking().ToListAsync();

        public async Task<Company> GetByIdAsync(int id)
            => await _context.Companies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Company> GetByNameAsync(string name)
            => await _context.Companies.AsNoTracking().FirstOrDefaultAsync(x => x.Name_En == name || x.Name_Ar == name);

        public void CreateAsync(Company company) => _context.Companies.Add(company);
        public void UpdateAsync(Company company) => _context.Companies.Update(company);
        public void DeleteAsync(int id) => _context.Companies.Remove(new Company { Id = id });
    }
}
