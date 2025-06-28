namespace ContactApi.Interfaces
{
    public interface IValidationService
    {
        Task<bool> IsValidCategoryIdAsync(int? categoryId, CancellationToken cancellationToken = default);
        Task<bool> IsValidCategoryIdAsync(int categoryId, CancellationToken cancellationToken = default);
        Task<bool> IsValidBusinessSubcategoryIdAsync(int? businessSubcategoryId, CancellationToken cancellationToken = default);
        Task<bool> IsValidBusinessSubcategoryIdAsync(int businessSubcategoryId, CancellationToken cancellationToken = default);
    }
}