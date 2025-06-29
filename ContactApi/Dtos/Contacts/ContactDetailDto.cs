using ContactApi.Dtos.BusinessSubcategory;
using ContactApi.Dtos.Category;

namespace ContactApi.Dtos.Contacts
{
    public class ContactDetailDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? birthDate { get; set; }
        public CategoryDto Category { get; set; } = new CategoryDto();
        /// Only populated if Category = 'Służbowy'
        public BusinessSubcategoryDto ? BusinessSubcategory  { get; set; }
        /// Only populated if Category = 'inny'
        public string? OtherSubcategory { get; set; }
    }
}