using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hear_Read_WDT_Project.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public required string Name { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}
