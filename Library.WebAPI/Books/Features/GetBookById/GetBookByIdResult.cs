namespace Library.WebAPI.Books.Features.GetBookById;

public record GetBookByIdResult(
    bool Success,
    string? Message = null,
    Book? Book = null) : Result(Success, Message);