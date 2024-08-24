namespace Library.WebAPI.Books.Features.AddBook;

public record AddBookResult(
    bool Success,
    string? Message = null,
    Guid? BookId = null) : Result(Success, Message);