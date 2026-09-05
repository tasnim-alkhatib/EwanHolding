using EwanHolding.Application.Repositories.Interfaces;

namespace EwanHolding.Application.UnitOfWork
{
    public interface IUnitOfWork 
    {
        IAdminRepository Admins { get; }
        Task<int> SaveChangesAsync();
    }
}
