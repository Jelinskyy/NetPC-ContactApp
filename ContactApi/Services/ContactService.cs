using ContactApi.Dtos.Contacts;
using ContactApi.Interfaces;
using ContactApi.Mappers;

namespace ContactApi.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<List<ContactGeneralDto>> GetAllContactsAsync()
        {
            var contacts = await _contactRepository.GetAllContactsAsync();
            if (contacts == null || !contacts.Any())
            {
                return new List<ContactGeneralDto>();
            }
            return contacts.Select(c => c.ToContactGeneralDto()).ToList();
        }

        public async Task<ContactGeneralDto?> GetContactByIdAsync(int id)
        {
            var contact = await _contactRepository.GetContactById(id);
            if (contact == null)
            {
                return null;
            }
            return contact.ToContactGeneralDto();
        }     
        
        public async Task<ContactGeneralDto?> CreateContactAsync(CreateContactDto contactDto)
        {
            var contact = contactDto.ToContact();
            if (!string.IsNullOrEmpty(contactDto.Password))
            {
                contactDto.Password = BCrypt.Net.BCrypt.HashPassword(contactDto.Password);
            }
            
            contact = await _contactRepository.AddContactAsync(contact);
            
            return contact?.ToContactGeneralDto();
        }
    }
}