using EwanHolding.Application.DTOs;

namespace EwanHolding.Application.Services.Interfaces
{
    public interface ITermsAndConditionsService
    {
        Task<IEnumerable<TermsAndConditionsResponseDto>> GetAllAsync();
        Task<TermsAndConditionsResponseDto> GetByIdAsync(int id);
        Task CreateAsync(CreateTermsAndConditionsDto dto);
        Task UpdateAsync(UpdateTermsAndConditionsDto dto);
        Task DeleteAsync(int id);
    }
}