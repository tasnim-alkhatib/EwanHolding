using EwanHolding.Application.DTOs;
using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company> GetByIdAsync(int id);
        Task<Company> GetByNameAsync(string name);
        void CreateAsync(Company company);
        void UpdateAsync(Company company);
        void DeleteAsync(int id);
    }
}
