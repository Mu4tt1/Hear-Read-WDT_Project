using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class PublishingHouse
    {
        [Key]
        public int PublishingHouseId { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        public string Address { get; set; }
        [DisplayName("Contact Email")]

        public string ContactEmail { get; set; }

        public string PhoneNumber { get; set; }
        [ForeignKey("BookId")]
        [ValidateNever]
        public ICollection<Book> Books { get; set; }

    }
}
