using Microsoft.EntityFrameworkCore;

namespace Library_Management.Models
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options): base(options) { }
        public DbSet<Book> Books { get; set; } = default;
    }
}
