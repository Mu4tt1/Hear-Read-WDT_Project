using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class BookAuthor
    {
        [Key]
        public int BookAuthorId { get; set; }
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
