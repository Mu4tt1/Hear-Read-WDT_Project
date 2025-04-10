
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hear_Read_WDT_Project.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string SubscriptionType { get; set; } // ENUM(Free, Premium)
        public DateTime CreatedAt { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<DownloadLog> DownloadLogs { get; set; } = new List<DownloadLog>();
        public ICollection<OfflineAccess> OfflineAccesses { get; set; } = new List<OfflineAccess>();

    }
}