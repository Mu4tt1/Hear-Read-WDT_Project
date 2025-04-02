using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class BookAuthor
    {
        // Primary key for the BookAuthor relationship
        [Key]
        public int BookAuthorId { get; set; }

        // Foreign key for the Book entity
        public int BookId { get; set; }

        // Foreign key for the Author entity
        public int AuthorId { get; set; }

        // Navigation property for the associated Book
        [ForeignKey("BookId")]
        public virtual required Book Book { get; set; }

        // Navigation property for the associated Author
        [ForeignKey("AuthorId")]
        public virtual required Author Author { get; set; }
    }
}
