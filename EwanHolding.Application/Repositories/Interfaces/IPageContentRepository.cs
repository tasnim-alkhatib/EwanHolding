using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Repositories.Interfaces
{
    public interface IPageContentRepository
    {
        Task<IEnumerable<PageContent>> GetAllAsync();
        Task<IEnumerable<PageContent>> GetByPageNameAsync(string pageName);
        Task<PageContent> GetByIdAsync(int id);
        Task<PageContent> GetByKeyAsync(string key);
        void Create(PageContent content);
        void Update(PageContent content);
        void Delete(PageContent content);
    }
}