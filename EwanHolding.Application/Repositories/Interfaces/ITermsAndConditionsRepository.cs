using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Repositories.Interfaces
{
    public interface ITermsAndConditionsRepository
    {
        Task<IEnumerable<TermsAndConditions>> GetAllAsync();
        Task<TermsAndConditions> GetByIdAsync(int id);
        void Create(TermsAndConditions terms);
        void Update(TermsAndConditions terms);
        void Delete(TermsAndConditions terms);
    }
}