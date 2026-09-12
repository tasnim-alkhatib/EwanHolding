using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using EwanHolding.Application.UnitOfWork;
using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Services.Implementation
{
    public class TermsAndConditionsService : ITermsAndConditionsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TermsAndConditionsService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        private static TermsAndConditionsResponseDto ToDto(TermsAndConditions t) => new()
        {
            Id = t.Id,
            TitleAr = t.TitleAr,
            TitleEn = t.TitleEn,
            Description_Ar = t.Description_Ar,
            Description_En = t.Description_En
        };

        public async Task<IEnumerable<TermsAndConditionsResponseDto>> GetAllAsync()
            => (await _unitOfWork.TermsAndConditions.GetAllAsync()).Select(ToDto);

        public async Task<TermsAndConditionsResponseDto> GetByIdAsync(int id)
        {
            var terms = await _unitOfWork.TermsAndConditions.GetByIdAsync(id);
            if (terms == null) throw new Exception($"Terms with ID {id} not found.");
            return ToDto(terms);
        }

        public async Task CreateAsync(CreateTermsAndConditionsDto dto)
        {
            var terms = new TermsAndConditions
            {
                TitleAr = dto.TitleAr,
                TitleEn = dto.TitleEn,
                Description_Ar = dto.Description_Ar,
                Description_En = dto.Description_En
            };

            _unitOfWork.TermsAndConditions.Create(terms);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateTermsAndConditionsDto dto)
        {
            var terms = await _unitOfWork.TermsAndConditions.GetByIdAsync(dto.Id);
            if (terms == null) throw new Exception($"Terms with ID {dto.Id} not found.");

            terms.TitleAr = dto.TitleAr;
            terms.TitleEn = dto.TitleEn;
            terms.Description_Ar = dto.Description_Ar;
            terms.Description_En = dto.Description_En;
            terms.UpdatedAt = DateTime.Now;

            _unitOfWork.TermsAndConditions.Update(terms);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var terms = await _unitOfWork.TermsAndConditions.GetByIdAsync(id);
            if (terms == null) throw new Exception($"Terms with ID {id} not found.");

            _unitOfWork.TermsAndConditions.Delete(terms);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}