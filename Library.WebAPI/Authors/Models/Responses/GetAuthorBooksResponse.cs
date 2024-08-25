using Library.WebAPI.Books.Models.DTOs;

namespace Library.WebAPI.Authors.Models.Responses;

public record GetAuthorBooksResponse(
    bool Success,
    string? Message = null,
    IReadOnlyList<BookDto>? Books = null) : Response(Success, Message);