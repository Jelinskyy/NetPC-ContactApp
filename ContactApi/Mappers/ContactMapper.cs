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
    }
}