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
        public string PaymentMethod { get; set; } 
        public string PaymentStatus { get; set; } 
        public string TransactionId { get; set; }
        public DateTime PaymentDate { get; set; }

        [ForeignKey("SubscriptionId")]
        public Subscription Subscription { get; set; }
    }
}
