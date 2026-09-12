using EwanHolding.Application.DTOs;

namespace EwanHolding.Application.Services.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactResponseDto>> GetAllAsync();
        Task<ContactResponseDto> GetByIdAsync(int id);
        Task CreateAsync(CreateContactDto dto);
        Task UpdateStatusAsync(UpdateContactStatusDto dto);
        Task DeleteAsync(int id);
    }
}