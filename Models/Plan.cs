using System.ComponentModel.DataAnnotations;

namespace Hear_Read_WDT_Project.Models
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int DurationInDays { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
