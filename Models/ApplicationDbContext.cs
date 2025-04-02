using Microsoft.EntityFrameworkCore;

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
        public DbSet<Copyright> Copyrights { get; set; }  // Added Copyright DbSet

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Enforcing unique 'Name' in the 'Category' table
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();  // Ensure that 'Name' column in 'Category' is unique

            // 2. Defining composite keys for 'BookAuthor' and 'BookCategory'
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });  // Composite key for 'BookAuthor' (BookId + AuthorId)

            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });  // Composite key for 'BookCategory' (BookId + CategoryId)

            // 3. Defining relationships for 'BookCategory'
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany()
                .HasForeignKey(bc => bc.BookId);  // Many-to-one relationship between 'BookCategory' and 'Book'

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany()
                .HasForeignKey(bc => bc.CategoryId);  // Many-to-one relationship between 'BookCategory' and 'Category'

            // 4. Defining relationships for 'DownloadLog'
            modelBuilder.Entity<DownloadLog>()
                .HasOne(dl => dl.User)
                .WithMany()
                .HasForeignKey(dl => dl.UserId);  // Many-to-one relationship between 'DownloadLog' and 'User'

            modelBuilder.Entity<DownloadLog>()
                .HasOne(dl => dl.Book)
                .WithMany()
                .HasForeignKey(dl => dl.BookId);  // Many-to-one relationship between 'DownloadLog' and 'Book'

            // 5. Defining relationships for 'OfflineAccess'
            modelBuilder.Entity<OfflineAccess>()
                .HasOne(oa => oa.User)
                .WithMany()
                .HasForeignKey(oa => oa.UserId);  // Many-to-one relationship between 'OfflineAccess' and 'User'

            modelBuilder.Entity<OfflineAccess>()
                .HasOne(oa => oa.Book)
                .WithMany()
                .HasForeignKey(oa => oa.BookId);  // Many-to-one relationship between 'OfflineAccess' and 'Book'

            // 6. Defining relationships for 'Payment'
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Subscription)
                .WithMany()
                .HasForeignKey(p => p.SubscriptionId);  // Many-to-one relationship between 'Payment' and 'Subscription'

            // 7. Defining relationships for 'Review'
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);  // Many-to-one relationship between 'Review' and 'User'

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany()
                .HasForeignKey(r => r.BookId);  // Many-to-one relationship between 'Review' and 'Book'

            // 8. Defining relationships for 'Subscription'
            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId);  // Many-to-one relationship between 'Subscription' and 'User'

            // 9. Adding a default value for the 'CreatedAt' field in 'Review' to automatically set it to the current date and time
            modelBuilder.Entity<Review>()
                .Property(r => r.CreatedAt)
                .HasDefaultValueSql("GETDATE()");  // Default value set to the current date

            // 10. Making the 'Title' column of 'Book' unique to prevent duplicate book titles
            modelBuilder.Entity<Book>()
                .HasIndex(b => b.Title)
                .IsUnique();  // Ensure that 'Title' column in 'Book' is unique

            // 11. Enabling soft delete for 'Book' by adding an 'IsDeleted' field
            modelBuilder.Entity<Book>()
                .Property(b => b.IsDeleted)
                .HasDefaultValue(false);  // Add 'IsDeleted' with a default value of false (soft delete feature)

            modelBuilder.Entity<Book>()
                .HasQueryFilter(b => !b.IsDeleted);  // Ensures that only non-deleted books are retrieved by default
        }
    }
}
