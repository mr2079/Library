namespace Library.WebAPI.Books.Features.GetBooks;

public record GetBooksResult(
    bool Success,
    string? Message = null,
    IReadOnlyList<Book>? Books = null) : Result(Success, Message);