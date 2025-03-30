using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hear_Read_WDT_Project.Models
{
    public class DownloadLog
    {
        [Key]
        public int LogId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime DownloadDate { get; set; }
        public required string DeviceInfo { get; set; }
        public required string IpAddress { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }

    }
}
