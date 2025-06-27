using System.ComponentModel.DataAnnotations;

namespace ContactApi.Models
{
    // Represents a category of contacts, such as "Business", "Personal", etc.
    // The Category class is used to categorize contacts and can include subcategories.
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}