using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using EwanHolding.Application.UnitOfWork;
using EwanHolding.Domain.Entities;
using EwanHolding.Domain.Enums;

namespace EwanHolding.Application.Services.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        private static ContactResponseDto ToDto(Contact c) => new()
        {
            Id = c.Id,
            FullName = c.FullName,
            Email = c.Email,
            Phone = c.Phone,
            Subject = c.Subject,
            Message = c.Message,
            Status = c.Status,
            CreatedAt = c.CreatedAt
        };

        public async Task<IEnumerable<ContactResponseDto>> GetAllAsync()
            => (await _unitOfWork.Contacts.GetAllAsync()).Select(ToDto);

        public async Task<ContactResponseDto> GetByIdAsync(int id)
        {
            var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
            if (contact == null) throw new Exception($"Contact with ID {id} not found.");
            return ToDto(contact);
        }

        public async Task CreateAsync(CreateContactDto dto)
        {
            var contact = new Contact
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                Subject = dto.Subject,
                Message = dto.Message,
                Status = ContactStatus.Unread
            };

            _unitOfWork.Contacts.Create(contact);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(UpdateContactStatusDto dto)
        {
            var contact = await _unitOfWork.Contacts.GetByIdAsync(dto.Id);
            if (contact == null) throw new Exception($"Contact with ID {dto.Id} not found.");

            contact.Status = dto.Status;
            contact.UpdatedAt = DateTime.Now;

            _unitOfWork.Contacts.Update(contact);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
            if (contact == null) throw new Exception($"Contact with ID {id} not found.");

            _unitOfWork.Contacts.Delete(contact);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}