using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hear_Read_WDT_Project.Models
{
    public class Review
    {
        [Key]
        public int Review_id { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

         
        public int UserId { get; set; }

        public int BookId { get; set; }

        public DateTime Created_at { get; set; }


        [ForeignKey("UserID")]
        public User user { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }

    }
}
