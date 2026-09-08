using EwanHolding.Application.Repositories.Interfaces;
using EwanHolding.Domain.Entities;
using EwanHolding.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EwanHolding.Application.Repositories.Implementation
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly EwanHoldingDbContext _context;
        public ServiceRepository(EwanHoldingDbContext context) => _context = context;
        public async Task<IEnumerable<Service>> GetAllAsync()
            => await _context.Services.Include(x => x.Company).AsNoTracking().ToListAsync();

        public async Task<Service> GetByIdAsync(int id)
            => await _context.Services.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);

        public async Task<Service> GetByNameAsync(string name)
            => await _context.Services.AsNoTracking().FirstOrDefaultAsync(s => s.Name_Ar == name || s.Name_En == name);

        public void Create(Service service) => _context.Services.Add(service);
        public void Update(Service service) => _context.Services.Update(service);
        public void Delete(Service service) => _context.Services.Remove(service);
    }
}
