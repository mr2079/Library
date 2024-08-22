using Library.WebAPI.Authors.Models;
using Library.WebAPI.Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.WebAPI.Persistence;

public class LibraryDbContext(
    DbContextOptions<LibraryDbContext> options) : DbContext(options), ISaveChanges
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
}