using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Repositories.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllAsync();
        Task<Service> GetByIdAsync(int id);
        Task<Service> GetByNameAsync(string name);
        void Create(Service service);
        void Update(Service service);
        void Delete(Service service);
    }
}
