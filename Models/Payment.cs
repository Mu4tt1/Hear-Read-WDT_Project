using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hear_Read_WDT_Project.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int SubscriptionId { get; set; }
        public decimal Amount { get; set; }
        public required string PaymentMethod { get; set; } 
        public required string PaymentStatus { get; set; } 
        public required string TransactionId { get; set; }
        public DateTime PaymentDate { get; set; }

        [ForeignKey("SubscriptionId")]
        public required Subscription Subscription { get; set; }
    }
}
