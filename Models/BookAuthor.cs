using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class BookAuthor
    {
        [Key]
        public int BookAuthorId { get; set; }

        public int BookId { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        [ForeignKey("AuthorId")]
        public virtual required Author Author { get; set; }
    }
}
