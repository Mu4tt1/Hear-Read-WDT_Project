
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hear_Read_WDT_Project.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}