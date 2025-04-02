using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hear_Read_WDT_Project.Models
{
    public class Author
    {
        // Primary key for the 'Author' entity
        [Key]
        public int AuthorId { get; set; }

        // Required property for the author's name
        [Required]
        public required string Name { get; set; }

        // Required property for the author's biography
        [Required]
        public required string Bio { get; set; }

        // Navigation property to 'BookAuthor' for many-to-many relationship with 'Book'
        public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

        // Soft delete flag: marks whether an author is considered deleted (used in soft delete scenarios)
        public bool IsDeleted { get; internal set; } // 'internal' to ensure it can be accessed within the same assembly
    }
}
