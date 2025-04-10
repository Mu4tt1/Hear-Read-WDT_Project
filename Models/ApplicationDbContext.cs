using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Hear_Read_WDT_Project.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Narrator> Narrators { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<DownloadLog> DownloadLogs { get; set; }
        public DbSet<OfflineAccess> OfflineAccesses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<AuthorCopyright> AuthorCopyrights { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // OnModelCreating method to configure relationships, constraints, and other configurations
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // 1. Enforcing a unique 'Name' column in the 'Category' table to avoid duplicate names
        //    modelBuilder.Entity<Category>()
        //        .HasIndex(c => c.Name)
        //        .IsUnique();

        //    // 2. Composite keys for 'BookAuthor' and 'BookCategory' to link books to authors and categories respectively
        //    modelBuilder.Entity<BookAuthor>()
        //        .HasKey(ba => new { ba.BookId, ba.AuthorId });

        //    modelBuilder.Entity<BookCategory>()
        //        .HasKey(bc => new { bc.BookId, bc.CategoryId });

        //    // 3. Defining relationships for 'BookCategory' (Many-to-one relationship between Book and Category)
        //    modelBuilder.Entity<BookCategory>()
        //        .HasOne(bc => bc.Book)
        //        .WithMany()
        //        .HasForeignKey(bc => bc.BookId);

        //    modelBuilder.Entity<BookCategory>()
        //        .HasOne(bc => bc.Category)
        //        .WithMany()
        //        .HasForeignKey(bc => bc.CategoryId);

        //    // 4. Defining relationships for 'DownloadLog' (Many-to-one relationship between DownloadLog and User/Book)
        //    modelBuilder.Entity<DownloadLog>()
        //        .HasOne(dl => dl.User)
        //        .WithMany()
        //        .HasForeignKey(dl => dl.UserId)
        //        .OnDelete(DeleteBehavior.Restrict);  // Prevents cascading delete (when a user is deleted)

        //    modelBuilder.Entity<DownloadLog>()
        //        .HasOne(dl => dl.Book)
        //        .WithMany()
        //        .HasForeignKey(dl => dl.BookId)
        //        .OnDelete(DeleteBehavior.Restrict);  // Prevents cascading delete (when a book is deleted)

        //    // 5. Defining relationships for 'OfflineAccess' (Many-to-one relationship between OfflineAccess and User/Book)
        //    modelBuilder.Entity<OfflineAccess>()
        //        .HasOne(oa => oa.User)
        //        .WithMany()
        //        .HasForeignKey(oa => oa.UserId)
        //        .OnDelete(DeleteBehavior.Restrict);  // Prevents cascading delete (when a user is deleted)

        //    modelBuilder.Entity<OfflineAccess>()
        //        .HasOne(oa => oa.Book)
        //        .WithMany()
        //        .HasForeignKey(oa => oa.BookId)
        //        .OnDelete(DeleteBehavior.Restrict);  // Prevents cascading delete (when a book is deleted)

        //    // 6. Defining relationships for 'Payment' (Many-to-one relationship between Payment and Subscription)
        //    modelBuilder.Entity<Payment>()
        //        .HasOne(p => p.Subscription)
        //        .WithMany()
        //        .HasForeignKey(p => p.SubscriptionId)
        //        .OnDelete(DeleteBehavior.Cascade);  // Cascades delete for payment when subscription is deleted

        //    // 7. Defining relationships for 'Review' (Many-to-one relationship between Review and User/Book)
        //    modelBuilder.Entity<Review>()
        //        .HasOne(r => r.User)
        //        .WithMany()
        //        .HasForeignKey(r => r.UserId)
        //        .OnDelete(DeleteBehavior.Restrict);  // Prevents cascading delete (when a user is deleted)

        //    modelBuilder.Entity<Review>()
        //        .HasOne(r => r.Book)
        //        .WithMany()
        //        .HasForeignKey(r => r.BookId)
        //        .OnDelete(DeleteBehavior.Restrict);  // Prevents cascading delete (when a book is deleted)

        //    // 8. Defining relationships for 'Subscription' (Many-to-one relationship between Subscription and User)
        //    modelBuilder.Entity<Subscription>()
        //        .HasOne(s => s.User)
        //        .WithMany()
        //        .HasForeignKey(s => s.UserId)
        //        .OnDelete(DeleteBehavior.Restrict);  // Prevents cascading delete (when a user is deleted)

        //    // 9. Adding a default value for the 'CreatedAt' field in 'Review' to automatically set it to the current date and time
        //    modelBuilder.Entity<Review>()
        //        .Property(r => r.CreatedAt)
        //        .HasDefaultValueSql("GETDATE()");  // Default value for 'CreatedAt' field is set to the current date

        //    // 10. Making the 'Title' column of 'Book' unique to prevent duplicate book titles
        //    modelBuilder.Entity<Book>()
        //        .HasIndex(b => b.Title)
        //        .IsUnique();  // Ensures that 'Title' in 'Book' is unique

        //    // 11. Enabling soft delete for 'Book' by adding an 'IsDeleted' field
        //    modelBuilder.Entity<Book>()
        //        .Property(b => b.IsDeleted)
        //        .HasDefaultValue(false);  // Default value for 'IsDeleted' is false

        //    modelBuilder.Entity<Book>()
        //        .HasQueryFilter(b => !b.IsDeleted.HasValue || !b.IsDeleted.Value);  // Query filter ensures that only non-deleted books are retrieved

        //    // 12. Enabling soft delete for 'User', 'Author', and 'Category' (if needed)
        //    modelBuilder.Entity<User>()
        //        .Property(u => u.IsDeleted)
        //        .HasDefaultValue(false);  // Default value for 'IsDeleted' is false

        //    modelBuilder.Entity<User>()
        //        .HasQueryFilter(u => !u.IsDeleted);  // Ensures that deleted users are not retrieved

        //    modelBuilder.Entity<Author>()
        //        .Property(a => a.IsDeleted)
        //        .HasDefaultValue(false);  // Default value for 'IsDeleted' is false

        //    modelBuilder.Entity<Author>()
        //        .HasQueryFilter(a => !a.IsDeleted);  // Ensures that deleted authors are not retrieved

        //    // For the 'Category' entity, ensure that IsDeleted is nullable and set default
        //    modelBuilder.Entity<Category>()
        //        .Property(c => c.IsDeleted)
        //        .HasDefaultValue(false);  // Default value for 'IsDeleted' is false

        //    modelBuilder.Entity<Category>()
        //        .HasQueryFilter(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);  // Ensures that deleted categories are not retrieved

        //    // 13. Adding Index for 'CreatedAt' in Book and Review for better performance
        //    modelBuilder.Entity<Book>()
        //        .HasIndex(b => b.CreatedAt);  // Index on 'CreatedAt' to speed up queries based on book creation date

        //    modelBuilder.Entity<Review>()
        //        .HasIndex(r => r.CreatedAt);  // Index on 'CreatedAt' to speed up queries based on review creation date

        //    // 14. Concurrency Token for UpdatedAt (for optimistic concurrency control)
        //    modelBuilder.Entity<Book>()
        //        .Property(b => b.UpdatedAt)
        //        .IsConcurrencyToken();  // Allows for concurrency control on the 'UpdatedAt' field

        //    // 15. Full-Text Search for Book Description (optional, depending on DB engine)
        //    modelBuilder.Entity<Book>()
        //        .Property(b => b.Description)
        //        .HasColumnType("nvarchar(max)");  // Allows for full-text search on the 'Description' column

        //    // 16. Adding audit trail fields (CreatedBy, UpdatedBy) for tracking who created or updated the book
        //    modelBuilder.Entity<Book>()
        //        .Property(b => b.CreatedBy)
        //        .HasMaxLength(50);  // 'CreatedBy' field with a max length of 50

        //    modelBuilder.Entity<Book>()
        //        .Property(b => b.UpdatedBy)
        //        .HasMaxLength(50);  // 'UpdatedBy' field with a max length of 50

        //    // 17. Index for Category + Book composite relationship (ensures unique pairing of Book and Category)
        //    modelBuilder.Entity<BookCategory>()
        //        .HasIndex(bc => new { bc.BookId, bc.CategoryId })
        //        .IsUnique();  // Ensures that a book can only be associated with a category once
    }
}