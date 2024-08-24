namespace Library.WebAPI.Books.Models.Responses;

public record GetBooksResponse(
    bool Success,
    string? Message = null,
    IReadOnlyList<Book>? Books = null) : Response(Success, Message);