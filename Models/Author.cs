using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hear_Read_WDT_Project.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Bio { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
