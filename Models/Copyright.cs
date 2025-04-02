using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class Copyright
    {
        [Key]
        public int CopyrightId { get; set; }

        [Required]  // Ensures that Publisher is required
        public required string Publisher { get; set; }

        [Required]  // Ensures that LicenseType is required
        public required string LicenseType { get; set; }

        public DateTime ExpirationDate { get; set; }

        [Required]  // Ensures that Terms are required
        public required string Terms { get; set; }

        // Default value for CreatedAt - automatically set to current UTC date and time when a record is created
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Key Relationships
        public int? BookId { get; set; }  // Nullable Foreign Key in case Copyright is not associated with a Book
        public int? AuthorId { get; set; }  // Nullable Foreign Key in case Copyright is not associated with an Author

        [ForeignKey("BookId")]
        public virtual required Book Book { get; set; }

        [ForeignKey("AuthorId")]
        public virtual required Author Author { get; set; }
    }
}
