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
        public Task<bool> IsValidBusinessSubcategoryIdAsync(int? businessSubcategoryId, CancellationToken cancellationToken = default)
        {
            if (businessSubcategoryId == null || businessSubcategoryId <= 0)
            {
                return Task.FromResult(false); // Invalid subcategory ID
            }
            return _businessSubcategoryRepository.ExistsByIdAsync(businessSubcategoryId);
        }

        public Task<bool> IsValidBusinessSubcategoryIdAsync(int businessSubcategoryId, CancellationToken cancellationToken = default)
        {
            return IsValidBusinessSubcategoryIdAsync((int?)businessSubcategoryId, cancellationToken);
        }

        public Task<bool> IsValidCategoryIdAsync(int? categoryId, CancellationToken cancellationToken = default)
        {
            if (categoryId == null || categoryId <= 0)
            {
                return Task.FromResult(false); // Invalid category ID
            }
            return _categoryRepository.ExistsByIdAsync(categoryId);
        }

        public Task<bool> IsValidCategoryIdAsync(int categoryId, CancellationToken cancellationToken = default)
        {
            return IsValidCategoryIdAsync((int?)categoryId, cancellationToken);
        }
    }
}