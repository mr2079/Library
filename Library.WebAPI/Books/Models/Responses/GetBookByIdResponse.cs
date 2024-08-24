namespace Library.WebAPI.Books.Models.Responses;

public record GetBookByIdResponse(
    bool Success,
    string? Message = null,
    Book? Book = null) : Response(Success, Message);