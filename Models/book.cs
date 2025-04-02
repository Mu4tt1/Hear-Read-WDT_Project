using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hear_Read_WDT_Project.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Path { get; set; }

        public TimeSpan Duration { get; set; }

        [Required]
        public string Language { get; set; }

        public float Rating { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        public int NarratorId { get; set; }
        public bool IsPremiumOnly { get; set; }
    }
}