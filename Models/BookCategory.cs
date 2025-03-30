﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class BookCategory
    {
        [Key]
        public int BookCategoryId { get; set; }

        public int BookId { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }

        [ForeignKey("CategoryId")]
        public required Category Category { get; set; }
    }
}
