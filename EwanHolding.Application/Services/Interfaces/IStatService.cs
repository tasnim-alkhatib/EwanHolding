using EwanHolding.Application.DTOs;

namespace EwanHolding.Application.Services.Interfaces
{
    public interface IStatService
    {
        Task<IEnumerable<StatResponseDto>> GetAllAsync();
        Task<StatResponseDto> GetByIdAsync(int id);
        Task CreateAsync(CreateStatDto statDto);
        Task UpdateAsync(UpdateStatDto statDto);
        Task DeleteAsync(int id);
    }
}
