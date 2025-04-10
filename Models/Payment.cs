using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int SubscriptionId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // ENUM(Credit Card, PayPal, Bank Transfer, Other)
        public string PaymentStatus { get; set; } // ENUM(Completed, Pending, Failed, Refunded)
        public string TransactionId { get; set; }
        public DateTime PaymentDate { get; set; }

        [ForeignKey("SubscriptionId")]
        public Subscription Subscription { get; set; }
    }
}
