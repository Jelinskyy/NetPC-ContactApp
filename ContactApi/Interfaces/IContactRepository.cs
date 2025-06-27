using ContactApi.Models;

namespace ContactApi.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllContactsAsync();
    }
}