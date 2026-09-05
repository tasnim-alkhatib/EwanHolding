using EwanHolding.Infrastructure.Persistence;
using EwanHolding.Application.Repositories.Interfaces;
using EwanHolding.Application.Repositories.Implementation;

namespace EwanHolding.Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EwanHoldingDbContext _context;

        public IAdminRepository Admins { get; private set; }
        public UnitOfWork(EwanHoldingDbContext context)
        {
            _context = context;
            Admins = new AdminRepository(_context);
        }

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
