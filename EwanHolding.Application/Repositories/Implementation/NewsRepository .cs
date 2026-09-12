using EwanHolding.Application.Repositories.Interfaces;
using EwanHolding.Domain.Entities;
using EwanHolding.Domain.Enums;
using EwanHolding.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EwanHolding.Application.Repositories.Implementation
{
    public class NewsRepository : INewsRepository
    {
        private readonly EwanHoldingDbContext _context;
        public NewsRepository(EwanHoldingDbContext context) => _context = context;

        public async Task<IEnumerable<News>> GetAllAsync()
            => await _context.News.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<News>> GetPublishedAsync()
            => await _context.News.AsNoTracking().Where(n => n.Status == NewsStatus.Published).ToListAsync();

        public async Task<News> GetByIdAsync(int id)
            => await _context.News.AsNoTracking().FirstOrDefaultAsync(n => n.Id == id);

        public void Create(News news) => _context.News.Add(news);
        public void Update(News news) => _context.News.Update(news);
        public void Delete(News news) => _context.News.Remove(news);
    }
}