using ContactApi.Data;
using ContactApi.Interfaces;
using ContactApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactApi.Repositories
{
    public class ContacRepository : IContactRepository
    {
        private readonly AppDbContext _context;
        public ContacRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Contact?> AddContactAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return await _context.Contacts.AsNoTracking()
                .Include(c => c.Category)
                .Include(c => c.BusinessSubcategory)
                .FirstOrDefaultAsync(c => c.Id == contact.Id);
        }

        public Task DeleteContactAsync(Contact contact)
        {
            _context.Contacts.Remove(contact);
            return _context.SaveChangesAsync();
        }

        public async Task<List<Contact>> GetAllContactsAsync()
        {
            return await _context.Contacts.AsNoTracking()
                .Include(c => c.Category)
                .Include(c => c.BusinessSubcategory)
                .ToListAsync();
        }

        public async Task<Contact?> GetContactById(int id)
        {
            return await _context.Contacts.AsNoTracking()
                .Include(c => c.Category)
                .Include(c => c.BusinessSubcategory)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Contact?> UpdateContactAsync(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();

            return await _context.Contacts.AsNoTracking()
                .Include(c => c.Category)
                .Include(c => c.BusinessSubcategory)
                .FirstOrDefaultAsync(c => c.Id == contact.Id);
        }
    }
}