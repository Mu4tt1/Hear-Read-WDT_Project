using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace Hear_Read_WDT_Project.Models
{
    public class Caregory
    {
        [Key]
        public int category_id { get; set; }

        public string name { get; set; }

        public ICollection<book_category> book_Categories { get; set; } = new List<book_caregory>();

    }
}
