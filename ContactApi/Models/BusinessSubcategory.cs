using System.ComponentModel.DataAnnotations;

namespace ContactApi.Models
{
    // This class represents a subcategory of a business contact.
    public class BusinessSubcategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = "";
    }
}