namespace Library.WebAPI.Books.Models.Responses;

public record AddBookResponse(
    bool Success,
    string? Message = null,
    Guid? BookId = null) : Response(Success, Message);