using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Repositories.Interfaces
{
    public interface IInvestmentOpportunitiesRepository
    {
        Task<IEnumerable<InvestmentOpportunities>> GetAllAsync();
        Task<InvestmentOpportunities> GetByIdAsync(int id);
        Task<InvestmentOpportunities> GetByTitleAsync(string title);
        void Create(InvestmentOpportunities investmentOpportunity);
        void Update(InvestmentOpportunities investmentOpportunity);
        void Delete(InvestmentOpportunities investmentOpportunity);
    }
}
