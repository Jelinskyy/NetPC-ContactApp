using ContactApi.Dtos.Contacts;
using ContactApi.Models;

namespace ContactApi.Interfaces
{
    public interface IContactService
    {
        Task<List<ContactGeneralDto>> GetAllContactsAsync();
        Task<ContactDetailDto?> GetContactByIdAsync(int id);
        Task<ContactDetailDto?> CreateContactAsync(CreateContactDto contactDto);
        Task<ContactDetailDto?> UpdateContactAsync(int id, UpdateContactDto contactDto);
        Task DeleteContactAsync(int id);
    }
}