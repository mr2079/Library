namespace Library.WebAPI.Books.Features.GetBooksByAuthorId;

public record GetBooksByAuthorIdResult(
    bool Success,
    string? Message = null,
    IReadOnlyList<Book>? Books = null) : Result(Success, Message);