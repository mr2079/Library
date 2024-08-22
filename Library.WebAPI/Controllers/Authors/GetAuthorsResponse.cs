namespace Library.WebAPI.Controllers.Authors;

public record GetAuthorsResponse(
    bool Success,
    string? Message = null,
    IReadOnlyList<Author>? Authors = null) : Response(Success, Message);