using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class Payment
    {
        // The unique identifier for each payment
        [Key]
        public int PaymentId { get; set; }

        // Foreign key for Subscription. It connects the payment to a specific subscription
        public int SubscriptionId { get; set; }

        // The amount paid for the subscription
        public decimal Amount { get; set; }

        // The payment method used (e.g., Credit Card, PayPal)
        [Required]
        public required string PaymentMethod { get; set; }

        // The status of the payment (e.g., Completed, Pending)
        [Required]
        public required string PaymentStatus { get; set; }

        // The unique transaction identifier associated with the payment
        [Required]
        public required string TransactionId { get; set; }

        // The date when the payment was made. This is nullable to account for cases where the payment date may not be available or is delayed
        public DateTime? PaymentDate { get; set; }  // Nullable DateTime to handle cases where the payment date may be missing

        // Optional field to support soft delete. This field can be used to mark the payment as deleted without actually removing it from the database
        public bool? IsDeleted { get; set; }

        // Navigation property to the Subscription entity. This represents the relationship between Payment and Subscription
        [ForeignKey("SubscriptionId")]
        public virtual required Subscription Subscription { get; set; }

        // Optional: You can define delete behavior, for example:
        // OnDelete(DeleteBehavior.Cascade) will delete payments when the associated subscription is deleted.
        // OnDelete(DeleteBehavior.Restrict) will prevent deletion of subscriptions if related payments exist.
    }
}
