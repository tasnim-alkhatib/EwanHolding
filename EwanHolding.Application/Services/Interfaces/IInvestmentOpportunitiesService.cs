using EwanHolding.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

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
