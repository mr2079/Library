using Library.WebAPI.Books.Models.DTOs;

namespace Library.WebAPI.Books.Models.Responses;

public record GetBookByIdResponse(
    bool Success,
    string? Message = null,
    BookDto? Book = null) : Response(Success, Message);