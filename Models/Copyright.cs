using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class Copyright
    {
        [Key]
        public int CopyrightId { get; set; }

        public required string Publisher { get; set; }

        public required string LicenseType { get; set; }

        public DateTime ExpirationDate { get; set; }

        public required string Terms { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }

        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }

        public virtual required Author Author { get; set; }

        public virtual required BookCategory BookCategory { get; set; }
    }
}
