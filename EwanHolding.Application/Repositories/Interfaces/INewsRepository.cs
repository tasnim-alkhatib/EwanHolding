using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Repositories.Interfaces
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetAllAsync();
        Task<IEnumerable<News>> GetPublishedAsync();
        Task<News> GetByIdAsync(int id);
        void Create(News news);
        void Update(News news);
        void Delete(News news);
    }
}