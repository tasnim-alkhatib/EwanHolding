using EwanHolding.Application.Repositories.Interfaces;
using EwanHolding.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Repositories.Implementation
{
    public class AdminRepository : IAdminRepository
    {
        private readonly EwanHoldingDbContext _context;
        public AdminRepository(EwanHoldingDbContext context) => _context = context;

        public async Task<IEnumerable<Admin>> GetAllAsync()
            => await _context.Admins.AsNoTracking().ToListAsync();

        public async Task<Admin> GetByIdAsync(int id) 
            => await _context.Admins.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Admin> GetByEmailAsync(string email) 
            => await _context.Admins.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);

        public void Create(Admin admin) => _context.Admins.Add(admin);
        public void Update(Admin admin) => _context.Admins.Update(admin);
        public void Delete(Admin admin) => _context.Admins.Remove(admin);
    }
}