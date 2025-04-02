using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    // Represents a user's subscription
    public class Subscription
    {
        // Primary Key for Subscription table
        [Key]
        public int SubscriptionId { get; set; }

        // Foreign Key to the User table, each subscription is linked to a user
        public int UserId { get; set; }

        // The type of plan that the user has subscribed to (e.g., Basic, Premium)
        [Required]  // This field is mandatory
        public required string PlanType { get; set; }

        // The start date of the subscription
        public DateTime StartDate { get; set; }

        // The end date of the subscription
        public DateTime EndDate { get; set; }

        // A flag indicating if the user can download content as part of their subscription
        public bool CanDownload { get; set; }

        // Navigation property to User, linking the subscription to a user
        [ForeignKey("UserId")] // UserId is the foreign key for this relation
        public virtual required User User { get; set; }

        // Navigation property to Payments, one subscription can have multiple payments
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
