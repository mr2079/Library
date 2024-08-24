namespace Library.WebAPI.Books.Features.UpdateBook;

public record UpdateBookResult(
    bool Success,
    string? Message = null) : Result(Success, Message);