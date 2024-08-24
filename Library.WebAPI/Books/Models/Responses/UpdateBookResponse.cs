namespace Library.WebAPI.Books.Models.Responses;

public record UpdateBookResponse(
    bool Success,
    string? Message = null) : Response(Success, Message);