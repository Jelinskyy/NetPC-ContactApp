using ContactApi.Data;
using ContactApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactApi.Repositories
{
    public class BusinessSubcategoryRepository : IBusinessSubcategoryRepository
    {
        private readonly AppDbContext _context;
        public BusinessSubcategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> ExistsByIdAsync(int? id)
        {
            if (id == null || id <= 0)
            {
                return false; // Invalid subcategory ID
            }
            return await _context.BusinessSubcategories.AnyAsync(c => c.Id == id);
        }
    }
}