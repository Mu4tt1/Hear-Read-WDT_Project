using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hear_Read_WDT_Project.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public TimeSpan Duration { get; set; }
        public string Language { get; set; }
        public float Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPremiumOnly { get; set; }
        public int NarratorId { get; set; }

        [ForeignKey("NarratorId")]
        public Narrator Narrator { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<DownloadLog> DownloadLogs { get; set; } = new List<DownloadLog>();
        public ICollection<OfflineAccess> OfflineAccesses { get; set; } = new List<OfflineAccess>();
        public ICollection<AuthorCopyright> AuthorCopyrights { get; set; } = new List<AuthorCopyright>();
    }
}
