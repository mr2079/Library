namespace Library.WebAPI.Authors.Models.Responses;

public record AddAuthorResponse(
    bool Success,
    string? Message = null,
    Guid? AuthorId = null) : Response(Success, Message);