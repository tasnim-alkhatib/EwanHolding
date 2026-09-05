using EwanHolding.Application.DTOs;
using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetAllAsync();
        Task<Admin> GetByIdAsync(int id);
        Task<Admin> GetByEmailAsync(string email);
        void Create(Admin admin);
        void Update(Admin admin);
        void Delete(Admin admin);
    }
}
