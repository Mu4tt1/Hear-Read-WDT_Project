using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class DownloadLog
    {
        [Key]
        public int LogId { get; set; }

        public int? UserId { get; set; }  // Nullable Foreign Key
        public int? BookId { get; set; }  // Nullable Foreign Key
        public DateTime DownloadDate { get; set; } = DateTime.UtcNow;  // Default to current timestamp

        [Required]  // Ensures that DeviceInfo is required
        public required string DeviceInfo { get; set; }

        [Required]  // Ensures that IpAddress is required
        public required string IpAddress { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("BookId")]
        public virtual required Book Book { get; set; }
    }
}
