using EwanHolding.Application.DTOs;

namespace EwanHolding.Application.Services.Interfaces
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceResponseDto>> GetAllAsync();
        Task<ServiceResponseDto> GetByIdAsync(int id);
        Task CreateAsync(CreateServiceDto serviceDto);
        Task UpdateAsync(UpdateServiceDto serviceDto);
        Task DeleteAsync(int id);
    }
}
