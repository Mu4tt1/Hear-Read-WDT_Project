using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class OfflineAccess
    {
        [Key]
        public int OfflineId { get; set; }

        public int UserId { get; set; }  // Nullable Foreign Key, if needed: int? UserId
        public int BookId { get; set; }  // Nullable Foreign Key, if needed: int? BookId
        public DateTime DownloadDate { get; set; } = DateTime.UtcNow;  // Default to current timestamp
        public DateTime ValidUntil { get; set; }

        // Validation to ensure ValidUntil is greater than DownloadDate
        [NotMapped]
        public bool IsValid => ValidUntil > DownloadDate;

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("BookId")]
        public virtual required Book Book { get; set; }

        // Soft delete feature
        public bool? IsDeleted { get; set; }
    }
}
