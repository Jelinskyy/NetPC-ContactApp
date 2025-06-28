using ContactApi.Models;

namespace ContactApi.Interfaces
{
    public interface IContactRepository
    {
        Task<Contact?> AddContactAsync(Contact contact);
        Task<List<Contact>> GetAllContactsAsync();
        Task<Contact?> GetContactById(int id);
        Task<Contact?> UpdateContactAsync(Contact contact);
    }
}