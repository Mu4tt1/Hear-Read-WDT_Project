using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class Review
    {
        // The unique identifier for each review
        [Key]
        public int ReviewId { get; set; }

        // Rating for the book. Must be between 1 and 5.
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]  // Ensures rating is between 1 and 5
        public int Rating { get; set; }

        // The comment left by the user about the book
        [Required]
        public required string Comment { get; set; }

        // Foreign key reference to the User who created the review
        public int UserId { get; set; }

        // Foreign key reference to the Book being reviewed
        public int BookId { get; set; }

        // The date when the review was created
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Sets default to current UTC date and time

        // Navigation property to the User who wrote the review
        [ForeignKey("UserId")]
        public virtual required User User { get; set; }

        // Navigation property to the Book being reviewed
        [ForeignKey("BookId")]
        public virtual required Book Book { get; set; }
    }
}
