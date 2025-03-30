using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hear_Read_WDT_Project.Models
{
    public class Category_book
    {
        [Key]
        public int book_categories_id { get; set; }

        public int book_id { get; set; }

        public int category_id { get; set; }

        [ForeignKey("BookId")]
        public book book { get; set; }

        [ForeignKey("categoryId")]
        public Category Category { get; set; }


    }
}
