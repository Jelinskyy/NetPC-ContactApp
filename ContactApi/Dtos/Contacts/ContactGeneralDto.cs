using ContactApi.Dtos.BusinessSubcategory;
using ContactApi.Dtos.Category;

namespace ContactApi.Dtos.Contacts
{
    public class ContactGeneralDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public CategoryDto Category { get; set; } = new CategoryDto();
        /// Only populated if Category = 'Służbowy'
        public BusinessSubcategoryDto ? BusinessSubcategory  { get; set; }
        /// Only populated if Category = 'inny
        /// '
        public string? OtherSubcategory { get; set; }
    }
}