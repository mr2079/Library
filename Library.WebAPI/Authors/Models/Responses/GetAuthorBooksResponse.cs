namespace Library.WebAPI.Authors.Models.Responses;

public record GetAuthorBooksResponse(
    bool Success,
    string? Message = null,
    IReadOnlyList<Book>? Books = null) : Response(Success, Message);