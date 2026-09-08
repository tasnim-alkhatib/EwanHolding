using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using EwanHolding.Application.UnitOfWork;
using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        
        public async Task<IEnumerable<CompanyResponseDto>> GetAllAsync()
        {
            var companies = await _unitOfWork.Companies.GetAllAsync();
            
            var companyDtos = companies.Select(company => new CompanyResponseDto
            {
                Id = company.Id,
                Name_Ar = company.Name_Ar,
                Name_En = company.Name_En,
                Description_Ar = company.Description_Ar,
                Description_En = company.Description_En,
                WebsiteUrl = company.WebsiteUrl,
                LogoUrl = company.LogoUrl,
                IsActive = company.IsActive
            });

            return companyDtos;
        }

        public async Task<CompanyResponseDto> GetByIdAsync(int id)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(id);
            if(company == null) throw new Exception($"Company with ID {id} not found.");

            var companyDto = new CompanyResponseDto
            {
                Id = company.Id,
                Name_Ar = company.Name_Ar,
                Name_En = company.Name_En,
                Description_Ar = company.Description_Ar,
                Description_En = company.Description_En,
                WebsiteUrl = company.WebsiteUrl,
                LogoUrl = company.LogoUrl,
                IsActive = company.IsActive
            };

            return companyDto;
        }

        public async Task CreateAsync(CreateCompanyDto companyDto)
        {
            var nameEnExists = await _unitOfWork.Companies.GetByNameAsync(companyDto.Name_En);
            if (nameEnExists != null) throw new Exception($"Company with name {companyDto.Name_En} already exists.");
            
            var nameArExists = await _unitOfWork.Companies.GetByNameAsync(companyDto.Name_Ar);
            if(nameArExists != null) throw new Exception($"Company with name {companyDto.Name_Ar} already exists.");

            var newCompany = new Company
            {
                Name_Ar = companyDto.Name_Ar,
                Name_En = companyDto.Name_En,
                Description_Ar = companyDto.Description_Ar,
                Description_En = companyDto.Description_En,
                WebsiteUrl = companyDto.WebsiteUrl,
                LogoUrl = companyDto.LogoUrl,
                IsActive = companyDto.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            _unitOfWork.Companies.Create(newCompany);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateAsync(UpdateCompanyDto companyDto)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(companyDto.Id);
            if(company == null) throw new Exception($"Company with ID {companyDto.Id} not found.");

            company.Name_Ar = companyDto.Name_Ar;
            company.Name_En = companyDto.Name_En;
            company.Description_Ar = companyDto.Description_Ar;
            company.Description_En = companyDto.Description_En;
            company.LogoUrl = companyDto.LogoUrl;
            company.WebsiteUrl = companyDto.WebsiteUrl;
            company.IsActive = companyDto.IsActive;
            company.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Companies.Update(company);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(id);
            if (company == null) throw new Exception($"Company with ID {id} not found.");

            _unitOfWork.Companies.Delete(company.Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
