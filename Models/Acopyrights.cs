using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Reflection.Metadata.BlobBuilder;

namespace Hear_Read_WDT_Project.Models
{
    public class Acopyrights
    {
        public int Copyrights_id { get; set; }
        public string Publisher { get; set; }
        public string License_type { get; set; }
        public DateTime Expiration_date { get; set; }
        public string Terms { get; set; }
        public TimestampAttribute Created_at { get; set; }
        [ForeignKey("BookCategoryId")]
        public int BookId { get; set; }
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public virtual ICollection<Author> Author { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }

    }
}
