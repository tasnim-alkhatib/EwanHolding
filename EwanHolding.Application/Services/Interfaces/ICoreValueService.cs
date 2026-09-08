using EwanHolding.Application.DTOs;

namespace EwanHolding.Application.Services.Interfaces
{
    public interface ICoreValueService
    {
        Task<IEnumerable<CoreValueResponseDto>> GetAllAsync();
        Task<CoreValueResponseDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCoreValueDto coreValueDto);
        Task UpdateAsync(UpdateCoreValueDto coreValueDto);
        Task DeleteAsync(int id);
    }
}
