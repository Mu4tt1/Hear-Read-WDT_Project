using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hear_Read_WDT_Project.Models
{
    public class Narrator
    {
        // Primary key
        [Key]
        public int NarratorId { get; set; }

        // Name of the narrator
        [Required]
        public required string Name { get; set; }

        // Short biography or description
        public string? Bio { get; set; }

        // Navigation property: books narrated by this narrator
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}