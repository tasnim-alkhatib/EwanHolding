using EwanHolding.Application.DTOs;

namespace EwanHolding.Application.Services.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminResponseDto>> GetAllAsync();  
        Task<AdminResponseDto> GetByIdAsync(int id);
        Task CreateAsync(CreateAdminDto adminRequestDto);
        Task UpdateAsync(UpdateAdminDto adminRequestDto);
        Task DeleteAsync(int id);
        Task<AdminResponseDto> LoginAsync(LoginDto loginDto);
    }
}
