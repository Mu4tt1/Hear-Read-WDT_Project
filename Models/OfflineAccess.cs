using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class OfflineAccess
    {
        [Key]
        public int OfflineId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime DownloadDate { get; set; }
        public DateTime ValidUntil { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}
