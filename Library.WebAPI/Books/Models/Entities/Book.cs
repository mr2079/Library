namespace Library.WebAPI.Books.Models.Entities;

public class Book : Entity
{
    public Guid? AuthorId { get; set; }
    public string Title { get; set; }
    public int PublishedYear { get; set; }

    public Author? Author { get; set; }
}