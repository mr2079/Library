using Library.WebAPI.Authors.Models.DTOs;

namespace Library.WebAPI.Authors.Models.Responses;

public record GetAuthorsResponse(
    bool Success,
    string? Message = null,
    IReadOnlyList<AuthorDto>? Authors = null) : Response(Success, Message);