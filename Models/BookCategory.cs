using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class BookCategory
    {
        [Key]
        public int BookCategoryId { get; set; }
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
