using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
  public class LibraryContext : DbContext
  {
    public virtual DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<AuthorBook> AuthorBook {get; set; }
    
    // public DbSet<Copy> Copies { get; set; }
    // public DbSet<BookCopy> BookCopy { get; set; }
    
    public LibraryContext(DbContextOptions options) : base(options) { }
  }
}