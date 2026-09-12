using EwanHolding.Application.DTOs;

namespace EwanHolding.Application.Services.Interfaces
{
    public interface IInvestmentOpportunitiesService
    {
        Task<IEnumerable<InvestmentOpportunitiesResponseDto>> GetAllAsync();
        Task<InvestmentOpportunitiesResponseDto> GetByIdAsync(int id);
        Task CreateAsync(CreateInvestmentOpportunitiesDto investmentOpportunityDto);
        Task UpdateAsync(UpdateInvestmentOpportunitiesDto investmentOpportunityDto);
        Task DeleteAsync(int id);
    }
}
