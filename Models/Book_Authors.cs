using System.ComponentModel.DataAnnotations.Schema;
using static System.Reflection.Metadata.BlobBuilder;

namespace Hear_Read_WDT_Project.Models
{
    public class Book_Authors
    {
        public int Book_Authors_id { get; set; }
        [ForeignKey("BookCategoryId")]

        public int BookId { get; set; }
        [ForeignKey("AuthorId")]

        public int AuthorId { get; set; }
        public virtual ICollection<Author> Author { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}
