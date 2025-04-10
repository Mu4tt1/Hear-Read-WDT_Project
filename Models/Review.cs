﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}
