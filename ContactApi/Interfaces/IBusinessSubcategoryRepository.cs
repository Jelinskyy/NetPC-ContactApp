namespace ContactApi.Interfaces
{
    public interface IBusinessSubcategoryRepository
    {
        Task<bool> ExistsByIdAsync(int? id);
    }
}