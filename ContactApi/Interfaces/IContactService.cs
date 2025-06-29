using ContactApi.Dtos.Contacts;
using ContactApi.Models;

namespace ContactApi.Interfaces
{
    public interface IContactService
    {
        Task<List<ContactGeneralDto>> GetAllContactsAsync();
        Task<ContactGeneralDto?> GetContactByIdAsync(int id);
        Task<ContactGeneralDto?> CreateContactAsync(CreateContactDto contactDto);
        Task<ContactGeneralDto?> UpdateContactAsync(int id, UpdateContactDto contactDto);
        Task DeleteContactAsync(int id);
    }
}