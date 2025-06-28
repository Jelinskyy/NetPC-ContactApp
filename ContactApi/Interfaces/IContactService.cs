using ContactApi.Dtos.Contacts;

namespace ContactApi.Interfaces
{
    public interface IContactService
    {
        Task<List<ContactGeneralDto>> GetAllContactsAsync();
        Task<ContactGeneralDto?> GetContactByIdAsync(int id);
        Task<ContactGeneralDto?> CreateContactAsync(CreateContactDto contactDto);
    }
}