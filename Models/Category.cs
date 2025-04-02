using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hear_Read_WDT_Project.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public required string Name { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();

        // Mark the category as deleted or not, default value is false (not deleted)
        public bool? IsDeleted { get; set; } // Nullable to allow for handling of deleted status
    }
}
