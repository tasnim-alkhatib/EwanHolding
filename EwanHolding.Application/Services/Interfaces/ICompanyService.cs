using EwanHolding.Application.DTOs;

namespace EwanHolding.Application.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyResponseDto>> GetAllAsync();
        Task<CompanyResponseDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCompanyDto companyDto);
        Task UpdateAsync(UpdateCompanyDto companyDto);
        Task DeleteAsync(int id);
    }
}
