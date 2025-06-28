using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactApi.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)] 
        public string LastName { get; set; } = string.Empty;

        [EmailAddress]
        [MaxLength(255)]
        public string? Email { get; set; }

        [Phone]
        [MaxLength(20)]
        public string? Phone { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public string? PasswordHash { get; set; }

        // Foreign key to Category
        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        // Foreign key to BusinessSubcategoryId, optional
        [ForeignKey(nameof(BusinessSubcategory))]
        public int? BusinessSubcategoryId { get; set; }
        public BusinessSubcategory? BusinessSubcategory { get; set; }

        // Free text for other subcategory if Category = "Other"
        [MaxLength(100)]
        public string? OtherSubcategory { get; set; }
    }
}