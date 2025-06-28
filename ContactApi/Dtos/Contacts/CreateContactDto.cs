using System.ComponentModel.DataAnnotations;

namespace ContactApi.Dtos.Contacts
{
    public class CreateContactDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string LastName { get; set; }

        [EmailAddress]
        [MaxLength(255)]
        public string? Email { get; set; }

        [Phone]
        [MaxLength(20)]
        public string? Phone { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public string? Password { get; set; }

        // Foreign key to Category
        [Required]
        public int CategoryId { get; set; }

        // Foreign key to Subcategory, optional
        public int? BusinessSubcategoryId { get; set; }

        // Free text for other subcategory if Category = "Other"
        [MaxLength(100)]
        public string? OtherSubcategory { get; set; }
    }
}