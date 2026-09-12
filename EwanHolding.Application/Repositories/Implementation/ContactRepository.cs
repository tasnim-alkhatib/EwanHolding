using EwanHolding.Application.Repositories.Interfaces;
using EwanHolding.Domain.Entities;
using EwanHolding.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EwanHolding.Application.Repositories.Implementation
{
    public class ContactRepository : IContactRepository
    {
        private readonly EwanHoldingDbContext _context;
        public ContactRepository(EwanHoldingDbContext context) => _context = context;

        public async Task<IEnumerable<Contact>> GetAllAsync()
            => await _context.Contacts.AsNoTracking().ToListAsync();

        public async Task<Contact> GetByIdAsync(int id)
            => await _context.Contacts.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        public void Create(Contact contact) => _context.Contacts.Add(contact);
        public void Update(Contact contact) => _context.Contacts.Update(contact);
        public void Delete(Contact contact) => _context.Contacts.Remove(contact);
    }
}