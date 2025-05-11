using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [Required]
        public string Content { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedAt { get; set; }

        public Book Book { get; set; }

        public User User { get; set; }
    }
}
