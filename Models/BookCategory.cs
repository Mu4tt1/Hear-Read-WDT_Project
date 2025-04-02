using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class BookCategory
    {
        [Key]
        public int BookCategoryId { get; set; }

        // Foreign key for the Book entity
        public int BookId { get; set; }

        // Foreign key for the Category entity
        public int CategoryId { get; set; }

        // Navigation property for the associated Book
        [ForeignKey("BookId")]
        public required Book Book { get; set; }

        // Navigation property for the associated Category
        [ForeignKey("CategoryId")]
        public required Category Category { get; set; }
    }
}
