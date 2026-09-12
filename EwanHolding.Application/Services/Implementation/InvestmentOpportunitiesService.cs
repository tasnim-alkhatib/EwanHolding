using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using EwanHolding.Application.UnitOfWork;
using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Services.Implementation
{
    public class InvestmentOpportunitiesService : IInvestmentOpportunitiesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public InvestmentOpportunitiesService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        
        public async Task<IEnumerable<InvestmentOpportunitiesResponseDto>> GetAllAsync()
        {
            var investments = await _unitOfWork.InvestmentOpportunities.GetAllAsync();

            var investmentDto = investments.Select(x => new InvestmentOpportunitiesResponseDto
            {
                Id = x.Id,
                Title_Ar = x.Title_Ar,
                Title_En = x.Title_En,
                Description_Ar = x.Description_Ar,
                Description_En = x.Description_En,
                CompanyId = x.CompanyId,
                Status = x.Status
            });

            return investmentDto;
        }

        public async Task<InvestmentOpportunitiesResponseDto> GetByIdAsync(int id)
        {
            var investment = await _unitOfWork.InvestmentOpportunities.GetByIdAsync(id);
            if (investment == null) throw new Exception($"Investment Opportunity with ID {id} not found.");

            var investmentDto = new InvestmentOpportunitiesResponseDto
            {
                Id = investment.Id,
                Title_Ar = investment.Title_Ar,
                Title_En = investment.Title_En,
                Description_Ar = investment.Description_Ar,
                Description_En = investment.Description_En,
                CompanyId = investment.CompanyId,
                Status = investment.Status
            };

            return investmentDto;
        }

        public async Task CreateAsync(CreateInvestmentOpportunitiesDto investmentOpportunityDto)
        {
            var titleExists = await _unitOfWork.InvestmentOpportunities.GetByTitleAsync(investmentOpportunityDto.Title_Ar)
                ?? await _unitOfWork.InvestmentOpportunities.GetByTitleAsync(investmentOpportunityDto.Title_En);
            if (titleExists != null) throw new Exception($"Investment Opportunity with this title already exists.");

            var newInvestment = new InvestmentOpportunities
            {
                Title_Ar = investmentOpportunityDto.Title_Ar,
                Title_En = investmentOpportunityDto.Title_En,
                Description_Ar = investmentOpportunityDto.Description_Ar,
                Description_En = investmentOpportunityDto.Description_En,
                CompanyId = investmentOpportunityDto.CompanyId,
                Status = investmentOpportunityDto.Status
            };

            _unitOfWork.InvestmentOpportunities.Create(newInvestment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateInvestmentOpportunitiesDto investmentOpportunityDto)
        {
            var investment = await _unitOfWork.InvestmentOpportunities.GetByIdAsync(investmentOpportunityDto.Id);
            if (investment == null) throw new Exception($"Investment Opportunity with ID {investmentOpportunityDto.Id} not found.");

            investment.Title_En = investmentOpportunityDto.Title_En;
            investment.Title_Ar = investmentOpportunityDto.Title_Ar;
            investment.Description_Ar = investmentOpportunityDto.Description_Ar;
            investment.Description_En = investmentOpportunityDto.Description_En;
            investment.CompanyId = investmentOpportunityDto.CompanyId;
            investment.Status = investmentOpportunityDto.Status;
            investment.UpdatedAt = DateTime.Now;

            _unitOfWork.InvestmentOpportunities.Update(investment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var investment = await _unitOfWork.InvestmentOpportunities.GetByIdAsync(id);
            if (investment == null) throw new Exception($"Investment Opportunity with ID {id} not found.");

            _unitOfWork.InvestmentOpportunities.Delete(investment);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}