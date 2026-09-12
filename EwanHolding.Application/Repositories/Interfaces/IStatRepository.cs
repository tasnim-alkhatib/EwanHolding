using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Repositories.Interfaces
{
    public interface IStatRepository
    {
        Task<IEnumerable<Stat>> GetAllAsync();
        Task<Stat> GetByIdAsync(int id);
        Task<Stat> GetByLabelAsync(string label);
        Task<Stat> GetByDisplayOrderAsync(int displayOrder);
        void Create(Stat stat);
        void Update(Stat stat);
        void Delete(Stat stat);
    }
}
