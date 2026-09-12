using EwanHolding.Application.DTOs;

namespace EwanHolding.Application.Services.Interfaces
{
    public interface IPageContentService
    {
        Task<IEnumerable<PageContentResponseDto>> GetAllAsync();
        Task<IEnumerable<PageContentResponseDto>> GetByPageNameAsync(string pageName);
        Task<PageContentResponseDto> GetByIdAsync(int id);
        Task CreateAsync(CreatePageContentDto dto);
        Task UpdateAsync(UpdatePageContentDto dto);
        Task DeleteAsync(int id);
    }
}