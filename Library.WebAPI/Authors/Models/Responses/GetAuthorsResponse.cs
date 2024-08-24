using Library.WebAPI.Authors.Models.Entities;

namespace Library.WebAPI.Authors.Models.Responses;

public record GetAuthorsResponse(
    bool Success,
    string? Message = null,
    IReadOnlyList<Author>? Authors = null) : Response(Success, Message);