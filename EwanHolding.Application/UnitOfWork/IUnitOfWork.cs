using EwanHolding.Application.Repositories.Implementation;
using EwanHolding.Application.Repositories.Interfaces;
using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.UnitOfWork
{
    public interface IUnitOfWork 
    {
        IAdminRepository Admins { get; }
        ICompanyRepository Companies { get; }
        IServiceRepository Services { get; }
        ICoreValueRepository CoreValues { get; }
        IStatRepository Stats { get; }
        IInvestmentOpportunitiesRepository InvestmentOpportunities { get; }
        INewsRepository News { get; }
        Task<int> SaveChangesAsync();
    }
}
