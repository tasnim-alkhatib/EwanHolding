using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using EwanHolding.Application.UnitOfWork;
using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Services.Implementation
{
    public class PageContentService : IPageContentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PageContentService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        private static PageContentResponseDto ToDto(PageContent p) => new()
        {
            Id = p.Id,
            Key = p.Key,
            Value_Ar = p.Value_Ar,
            Value_En = p.Value_En,
            PageName = p.PageName
        };

        public async Task<IEnumerable<PageContentResponseDto>> GetAllAsync()
            => (await _unitOfWork.PageContents.GetAllAsync()).Select(ToDto);

        public async Task<IEnumerable<PageContentResponseDto>> GetByPageNameAsync(string pageName)
            => (await _unitOfWork.PageContents.GetByPageNameAsync(pageName)).Select(ToDto);

        public async Task<PageContentResponseDto> GetByIdAsync(int id)
        {
            var content = await _unitOfWork.PageContents.GetByIdAsync(id);
            if (content == null) throw new Exception($"PageContent with ID {id} not found.");
            return ToDto(content);
        }

        public async Task CreateAsync(CreatePageContentDto dto)
        {
            var keyExists = await _unitOfWork.PageContents.GetByKeyAsync(dto.Key);
            if (keyExists != null) throw new Exception($"Key '{dto.Key}' already exists.");

            var content = new PageContent
            {
                Key = dto.Key,
                Value_Ar = dto.Value_Ar,
                Value_En = dto.Value_En,
                PageName = dto.PageName
            };

            _unitOfWork.PageContents.Create(content);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdatePageContentDto dto)
        {
            var content = await _unitOfWork.PageContents.GetByIdAsync(dto.Id);
            if (content == null) throw new Exception($"PageContent with ID {dto.Id} not found.");

            content.Value_Ar = dto.Value_Ar;
            content.Value_En = dto.Value_En;
            content.UpdatedAt = DateTime.Now;

            _unitOfWork.PageContents.Update(content);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var content = await _unitOfWork.PageContents.GetByIdAsync(id);
            if (content == null) throw new Exception($"PageContent with ID {id} not found.");

            _unitOfWork.PageContents.Delete(content);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}