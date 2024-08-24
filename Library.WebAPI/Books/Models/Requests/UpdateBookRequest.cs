namespace Library.WebAPI.Books.Models.Requests;

public record UpdateBookRequest(
    string Title,
    int PublishedYear);