using Library.WebAPI.Authors.Models.DTOs;

namespace Library.WebAPI.Authors.Models.Responses;

public record GetAuthorByIdResponse(
    bool Success,
    string? Message = null,
    AuthorDto? Author = null) : Response(Success, Message);