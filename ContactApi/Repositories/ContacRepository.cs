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
    }
}