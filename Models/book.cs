using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string CoverImageUrl { get; set; }

        public DateTime PublishedDate { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public int CategoryId { get; set; }
        [ForeignKey("NarratorId")]
        [ValidateNever]
        public int NarratorId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        [ForeignKey("PublishingHouseId")]
        [ValidateNever]
        public int PublishingHouseId { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
        [ValidateNever]
        public ICollection<BookAuthor> BookAuthors { get; set; }
        [ValidateNever]
        public ICollection<BookCategory> BookCategories { get; set; }
        [ValidateNever]
        public ICollection<Review> Reviews { get; set; }
    }
}
