namespace Library.WebAPI.Books.Models;

public class Book : Entity
{
    public Guid? AuthorId { get; set; }
    public required string Title { get; set; }
    public int PublishedYear { get; set; }

    public Author? Author { get; set; }
}