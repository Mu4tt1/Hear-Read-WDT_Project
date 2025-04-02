
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hear_Read_WDT_Project.Models
{
    public class User
    {
        // Primary key
        [Key]
        public int UserId { get; set; }

        // User's full name
        [Required]
        public required string Name { get; set; }

        // User's email
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        // Hashed password
        [Required]
        public required string Password_Hash { get; set; }

        // Date of account creation
        [Required]
        public DateTime Created_At { get; set; }

        // Type of subscription (e.g., Free, Premium, etc.)
        [Required]
        public required string Subscription_Type { get; set; }

        // Navigation properties (optional, based on your schema)

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

        public virtual ICollection<DownloadLog> DownloadLogs { get; set; } = new List<DownloadLog>();

        public virtual ICollection<OfflineAccess> OfflineAccesses { get; set; } = new List<OfflineAccess>();
    }
}