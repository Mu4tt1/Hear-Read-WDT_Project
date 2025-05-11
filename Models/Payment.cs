using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("PlanId")]
        public int PlanId { get; set; }

        public DateTime PaymentDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public string Status { get; set; }

        public User User { get; set; }

        public Plan Plan { get; set; }
    }
}
