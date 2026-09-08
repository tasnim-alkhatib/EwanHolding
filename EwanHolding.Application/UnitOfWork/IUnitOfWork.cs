using EwanHolding.Application.Repositories.Implementation;
using EwanHolding.Application.Repositories.Interfaces;

namespace EwanHolding.Application.UnitOfWork
{
    public interface IUnitOfWork 
    {
        IAdminRepository Admins { get; }
        ICompanyRepository Companies { get; }
        IServiceRepository Services { get; }
        ICoreValueRepository CoreValues { get; }
        Task<int> SaveChangesAsync();
    }
}
