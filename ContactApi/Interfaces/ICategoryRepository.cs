namespace ContactApi.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> ExistsByIdAsync(int? id);
    }
}