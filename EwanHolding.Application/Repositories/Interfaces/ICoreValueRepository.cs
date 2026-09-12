using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Repositories.Interfaces
{
    public interface ICoreValueRepository
    {
        Task<IEnumerable<CoreValue>> GetAllAsync();
        Task<CoreValue> GetByIdAsync(int id);
        Task<CoreValue> GetByTitleAsync(string title);
        Task<CoreValue> GetByDisplayOrderAsync(int displayOrder);
        void Create(CoreValue coreValue);
        void Update(CoreValue coreValue);
        void Delete(CoreValue coreValue);
    }
}
