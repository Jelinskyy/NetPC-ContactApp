using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApi.Interfaces;

namespace ContactApi.Services
{
    public class ValidationService : IValidationService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBusinessSubcategoryRepository _businessSubcategoryRepository;
        public ValidationService(ICategoryRepository categoryRepository, IBusinessSubcategoryRepository businessSubcategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _businessSubcategoryRepository = businessSubcategoryRepository;
        }
        public async Task<bool> IsValidBusinessSubcategoryIdAsync(int? businessSubcategoryId, CancellationToken cancellationToken = default)
        {
            if (businessSubcategoryId == null || businessSubcategoryId <= 0)
            {
                return false; // Invalid subcategory ID
            }
            return await _businessSubcategoryRepository.ExistsByIdAsync(businessSubcategoryId);
        }

        public async Task<bool> IsValidBusinessSubcategoryIdAsync(int businessSubcategoryId, CancellationToken cancellationToken = default)
        {
            return await IsValidBusinessSubcategoryIdAsync((int?)businessSubcategoryId, cancellationToken);
        }

        public async Task<bool> IsValidCategoryIdAsync(int? categoryId, CancellationToken cancellationToken = default)
        {
            if (categoryId == null || categoryId <= 0)
            {
                return false; // Invalid category ID
            }
            return await _categoryRepository.ExistsByIdAsync(categoryId);
        }

        public async Task<bool> IsValidCategoryIdAsync(int categoryId, CancellationToken cancellationToken = default)
        {
            return await IsValidCategoryIdAsync((int?)categoryId, cancellationToken);
        }
    }
}