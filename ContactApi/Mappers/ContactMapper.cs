using ContactApi.Dtos.Contacts;
using ContactApi.Models;

namespace ContactApi.Mappers
{
    public static class ContactMapper
    {
        public static ContactGeneralDto ToContactGeneralDto(this Contact contact)
        {
            return new ContactGeneralDto
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Category = contact.Category.ToCategoryDto(),
                BusinessSubcategory = contact.BusinessSubcategory == null ? null : contact.BusinessSubcategory.ToBusinessSubcategoryDto(),
                OtherSubcategory = contact.OtherSubcategory,
            };
        }

        public static Contact ToContact(this CreateContactDto dto)
        {
            return new Contact
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                DateOfBirth = dto.DateOfBirth,
                PasswordHash = string.IsNullOrEmpty(dto.Password) ? null : BCrypt.Net.BCrypt.HashPassword(dto.Password), // Move hshing logic to a service later
                CategoryId = dto.CategoryId,
                BusinessSubcategoryId = dto.BusinessSubcategoryId,
                OtherSubcategory = dto.OtherSubcategory
            };
        }
    }
}