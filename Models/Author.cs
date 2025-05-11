using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public string Bio { get; set; }
        [ForeignKey("BookId")]
        public int BookId { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
        
    }
}
