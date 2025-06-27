using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactApi.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } // Make unique via Fluent API

        public string? PasswordHash { get; set; }

        // Foreign key to Category
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        // Foreign key to Subcategory, optional
        [ForeignKey(nameof(BusinessSubcategory))]
        public int? BusinessSubcategoryId { get; set; }
        public BusinessSubcategory? BusinessSubcategory { get; set; }

        // Free text for other subcategory if Category = "Other"
        [MaxLength(100)]
        public string? OtherSubcategory { get; set; }

        [Phone]
        [MaxLength(20)]
        public string? Phone { get; set; }

        public DateTime? DateOfBirth { get; set; }

    }
}