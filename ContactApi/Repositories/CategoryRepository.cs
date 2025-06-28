using ContactApi.Data;
using ContactApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> ExistsByIdAsync(int? id)
        {
            if (id == null || id <= 0)
            {
                return false; // Invalid category ID
            }
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }
    }
}