namespace Library.WebAPI.Books.Models.Requests;

public record AddBookRequest(
    Guid AuthorId,
    string Title,
    int PublishedYear);