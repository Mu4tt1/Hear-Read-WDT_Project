using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }
        public int UserId { get; set; }
        public string PlanType { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CanDownload { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    }
}
