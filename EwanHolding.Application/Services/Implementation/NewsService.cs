using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using EwanHolding.Application.UnitOfWork;
using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Services.Implementation
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public NewsService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        private static NewsResponseDto ToDto(News n) => new()
        {
            Id = n.Id,
            Title_Ar = n.Title_Ar,
            Title_En = n.Title_En,
            Description_Ar = n.Description_Ar,
            Description_En = n.Description_En,
            PublishDate = n.PublishDate,
            Status = n.Status
        };

        public async Task<IEnumerable<NewsResponseDto>> GetAllAsync()
            => (await _unitOfWork.News.GetAllAsync()).Select(ToDto);

        public async Task<IEnumerable<NewsResponseDto>> GetPublishedAsync()
            => (await _unitOfWork.News.GetPublishedAsync()).Select(ToDto);

        public async Task<NewsResponseDto> GetByIdAsync(int id)
        {
            var news = await _unitOfWork.News.GetByIdAsync(id);
            if (news == null) throw new Exception($"News with ID {id} not found.");
            return ToDto(news);
        }

        public async Task CreateAsync(CreateNewsDto dto)
        {
            var news = new News
            {
                Title_Ar = dto.Title_Ar,
                Title_En = dto.Title_En,
                Description_Ar = dto.Description_Ar,
                Description_En = dto.Description_En,
                PublishDate = dto.PublishDate,
                Status = dto.Status
            };

            _unitOfWork.News.Create(news);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateNewsDto dto)
        {
            var news = await _unitOfWork.News.GetByIdAsync(dto.Id);
            if (news == null) throw new Exception($"News with ID {dto.Id} not found.");

            news.Title_Ar = dto.Title_Ar;
            news.Title_En = dto.Title_En;
            news.Description_Ar = dto.Description_Ar;
            news.Description_En = dto.Description_En;
            news.PublishDate = dto.PublishDate;
            news.Status = dto.Status;
            news.UpdatedAt = DateTime.Now;

            _unitOfWork.News.Update(news);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var news = await _unitOfWork.News.GetByIdAsync(id);
            if (news == null) throw new Exception($"News with ID {id} not found.");

            _unitOfWork.News.Delete(news);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}