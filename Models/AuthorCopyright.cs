using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class AuthorCopyright
    {
        [Key]
        public int BookCopyrightId { get; set; }
        public string Publisher { get; set; }
        public string LicenseType { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Terms { get; set; }
        public DateTime CreatedAt { get; set; }

        public int AuthorId { get; set; }
        public int BookId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }//hgo
    }
}
