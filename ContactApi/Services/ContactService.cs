using ContactApi.Dtos.Contacts;
using ContactApi.Interfaces;
using ContactApi.Mappers;

namespace ContactApi.Services
{

    // To Do:
    // - Add authorization for contact password 
    // - Repllace BCrypt with a identity framework for password hashing
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IValidationService _validationService;

        public ContactService(IContactRepository contactRepository, IValidationService validationService)
        {
            _validationService = validationService;
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

        public async Task<ContactDetailDto?> GetContactByIdAsync(int id)
        {
            var contact = await _contactRepository.GetContactById(id);
            if (contact == null)
            {
                return null;
            }
            return contact.ToContactDetailDto();
        }

        public async Task<ContactDetailDto?> CreateContactAsync(CreateContactDto contactDto)
        {
            var contact = contactDto.ToContact();

            // Check if CategoryId is valid
            if (!await _validationService.IsValidCategoryIdAsync(contactDto.CategoryId))
                throw new ArgumentException("Nieprawidłowa kategoria.");

            // Check if BusinessSubcategoryId is valid when CategoryId is Business
            if (contactDto.CategoryId == 2 && !await _validationService.IsValidBusinessSubcategoryIdAsync(contactDto.BusinessSubcategoryId))
                throw new ArgumentException("Nieprawidłowa subkategoria biznesowa.");

            // Hash the password if provided
            contactDto.Password = !String.IsNullOrEmpty(contactDto.Password) ?
                BCrypt.Net.BCrypt.HashPassword(contactDto.Password) :
                null;

            contact = await _contactRepository.AddContactAsync(contact);

            return contact?.ToContactDetailDto();
        }

        public async Task<ContactDetailDto?> UpdateContactAsync(int id, UpdateContactDto contactDto)
        {

            var contact = contactDto.ToContact();

            // Ensure the contact has the correct ID
            contact.Id = id;

            // Check if CategoryId is valid
            if (!await _validationService.IsValidCategoryIdAsync(contactDto.CategoryId))
                throw new ArgumentException("Nieprawidłowa kategoria.");

            // Check if BusinessSubcategoryId is valid when CategoryId is Business
            if (contactDto.CategoryId == 2 && !await _validationService.IsValidBusinessSubcategoryIdAsync(contactDto.BusinessSubcategoryId))
                throw new ArgumentException("Nieprawidłowa subkategoria biznesowa.");

            // Validate the contact ID exists in the repository
            var updatedContact = await _contactRepository.GetContactById(id).ContinueWith(async task =>
            {
                // If the contact with the specified ID does not exist, return null
                if (task.Result == null)
                {
                    return null;
                }

                // Hash the password if provided
                contact.PasswordHash = !string.IsNullOrEmpty(contactDto.Password)
                    ? BCrypt.Net.BCrypt.HashPassword(contactDto.Password)
                    : null;

                return await _contactRepository.UpdateContactAsync(contact);
            }).Unwrap();

            if (updatedContact == null)
            {
                return null; // Contact with the specified ID does not exist
            }

            return updatedContact.ToContactDetailDto();
        }

        public async Task DeleteContactAsync(int id)
        {
            // Validate the contact ID exists in the repository
            var contact = await _contactRepository.GetContactById(id);
            if (contact == null)
            {
                throw new ArgumentException($"Nie ma kontaktu o ID {id}.");
            }

            await _contactRepository.DeleteContactAsync(contact);
        }
    }
}