using EwanHolding.Application.Repositories.Interfaces;
using EwanHolding.Domain.Entities;
using EwanHolding.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EwanHolding.Application.Repositories.Implementation
{
    public class PageContentRepository : IPageContentRepository
    {
        private readonly EwanHoldingDbContext _context;
        public PageContentRepository(EwanHoldingDbContext context) => _context = context;

        public async Task<IEnumerable<PageContent>> GetAllAsync()
            => await _context.PageContents.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<PageContent>> GetByPageNameAsync(string pageName)
            => await _context.PageContents.AsNoTracking().Where(p => p.PageName == pageName).ToListAsync();

        public async Task<PageContent> GetByIdAsync(int id)
            => await _context.PageContents.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        public async Task<PageContent> GetByKeyAsync(string key)
            => await _context.PageContents.AsNoTracking().FirstOrDefaultAsync(p => p.Key == key);

        public void Create(PageContent content) => _context.PageContents.Add(content);
        public void Update(PageContent content) => _context.PageContents.Update(content);
        public void Delete(PageContent content) => _context.PageContents.Remove(content);
    }
}