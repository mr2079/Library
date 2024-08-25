using Library.WebAPI.Books.Models.DTOs;

namespace Library.WebAPI.Books.Models.Responses;

public record GetBooksResponse(
    bool Success,
    string? Message = null,
    IReadOnlyList<BookDto>? Books = null) : Response(Success, Message);