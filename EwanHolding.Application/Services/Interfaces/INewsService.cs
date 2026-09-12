using EwanHolding.Application.DTOs;

namespace EwanHolding.Application.Services.Interfaces
{
    public interface INewsService
    {
        Task<IEnumerable<NewsResponseDto>> GetAllAsync();
        Task<IEnumerable<NewsResponseDto>> GetPublishedAsync();
        Task<NewsResponseDto> GetByIdAsync(int id);
        Task CreateAsync(CreateNewsDto dto);
        Task UpdateAsync(UpdateNewsDto dto);
        Task DeleteAsync(int id);
    }
}