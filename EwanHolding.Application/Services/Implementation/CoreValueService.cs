using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using EwanHolding.Application.UnitOfWork;
using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Services.Implementation
{
    public class CoreValueService : ICoreValueService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoreValueService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<CoreValueResponseDto>> GetAllAsync()
        {
            var coreValues = await _unitOfWork.CoreValues.GetAllAsync();

            var coreValueDtos = coreValues.Select(cv => new CoreValueResponseDto
            {
                Id = cv.Id,
                Title_Ar = cv.Title_Ar,
                Title_En = cv.Title_En,
                Description_Ar = cv.Description_Ar,
                Description_En = cv.Description_En,
                IconUrl = cv.IconUrl,
                DisplayOrder = cv.DisplayOrder
            });

            return coreValueDtos;
        }

        public async Task<CoreValueResponseDto> GetByIdAsync(int id)
        {
            var coreValue = await _unitOfWork.CoreValues.GetByIdAsync(id);
            if (coreValue == null) throw new Exception($"Core value with ID {id} not found.");

            var coreValueDto = new CoreValueResponseDto
            {
                Id = coreValue.Id,
                Title_Ar = coreValue.Title_Ar,
                Title_En = coreValue.Title_En,
                Description_Ar = coreValue.Description_Ar,
                Description_En = coreValue.Description_En,
                IconUrl = coreValue.IconUrl,
                DisplayOrder = coreValue.DisplayOrder
            };

            return coreValueDto;
        }

        public async Task CreateAsync(CreateCoreValueDto coreValueDto)
        {
            var titleExists = await _unitOfWork.CoreValues.GetByTitleAsync(coreValueDto.Title_Ar)
                ?? await _unitOfWork.CoreValues.GetByTitleAsync(coreValueDto.Title_En);
            if (titleExists != null) throw new Exception($"Core value with this title already exists.");

            var displayOrderExists = await _unitOfWork.CoreValues.GetByDisplayOrderAsync(coreValueDto.DisplayOrder);
            if (displayOrderExists != null) throw new Exception($"Display order {coreValueDto.DisplayOrder} is already used.");

            var coreValue = new CoreValue
            {
                Title_Ar = coreValueDto.Title_Ar,
                Title_En = coreValueDto.Title_En,
                Description_Ar = coreValueDto.Description_Ar,
                Description_En = coreValueDto.Description_En,
                IconUrl = coreValueDto.IconUrl,
                DisplayOrder = coreValueDto.DisplayOrder
            };
            
            _unitOfWork.CoreValues.Create(coreValue);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateCoreValueDto coreValueDto)
        {
            var coreValue = await _unitOfWork.CoreValues.GetByIdAsync(coreValueDto.Id);
            if (coreValue == null) throw new Exception($"Core value with ID {coreValueDto.Id} not found.");

            var displayOrderExists = await _unitOfWork.CoreValues.GetByDisplayOrderAsync(coreValueDto.DisplayOrder);
            if (displayOrderExists != null && displayOrderExists.Id != coreValueDto.Id)
                throw new Exception($"Display order {coreValueDto.DisplayOrder} is already used.");

            coreValue.Title_Ar = coreValueDto.Title_Ar;
            coreValue.Title_En = coreValueDto.Title_En;
            coreValue.Description_En = coreValueDto.Description_En;
            coreValue.Description_Ar = coreValueDto.Description_Ar;
            coreValue.IconUrl = coreValueDto.IconUrl;
            coreValue.DisplayOrder = coreValueDto.DisplayOrder;
            coreValue.UpdatedAt = DateTime.Now;

            _unitOfWork.CoreValues.Update(coreValue);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var coreValue = await _unitOfWork.CoreValues.GetByIdAsync(id);
            if(coreValue == null) throw new Exception($"Core value with ID {id} not found.");

            _unitOfWork.CoreValues.Delete(coreValue);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
