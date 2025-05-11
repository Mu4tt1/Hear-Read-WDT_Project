using System.ComponentModel.DataAnnotations;

namespace Hear_Read_WDT_Project.Models
{
    public class Narrator
    {
        [Key]
        public int NarratorId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public string Bio { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
