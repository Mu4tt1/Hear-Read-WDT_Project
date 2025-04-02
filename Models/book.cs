using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hear_Read_WDT_Project.Models
{
    public class Book
    {
        // Primary key for the 'Book' entity
        [Key]
        public int BookId { get; set; }

        // Required property for the book's title
        [Required]
        public required string Title { get; set; }

        // Required property for the book's description
        [Required]
        public required string Description { get; set; }

        // Required property for the file path of the book
        [Required]
        public required string FilePath { get; set; }

        // Property for the duration of the book in TimeSpan format
        public TimeSpan Duration { get; set; }

        // Required property for the language of the book
        [Required]
        public required string Language { get; set; }

        // Average rating for the book
        public float AverageRating { get; set; }

        // Date when the book was published
        public DateTime PublishedAt { get; set; }

        // Foreign key for the 'Narrator' entity
        [Required]
        public int NarratorId { get; set; }

        // Flag to determine if the book requires a subscription to access
        public bool RequiresSubscription { get; set; }

        // Navigation property for the many-to-many relationship between 'Book' and 'Author'
        public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

        // Navigation property for the many-to-many relationship between 'Book' and 'Category'
        public virtual ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();

        // Navigation property for reviews related to the book
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        // Soft delete flag: marks whether the book is considered deleted (used for soft delete functionality)
        public bool? IsDeleted { get; set; } // Nullable to allow for handling of deleted status

        // Audit fields for tracking who created/updated the book and when
        public object? UpdatedBy { get; internal set; }  // Tracks who updated the book
        public object? CreatedBy { get; internal set; }  // Tracks who created the book
        public object? UpdatedAt { get; internal set; }  // Tracks when the book was last updated
        public object? CreatedAt { get; internal set; }  // Tracks when the book was created
    }
}
