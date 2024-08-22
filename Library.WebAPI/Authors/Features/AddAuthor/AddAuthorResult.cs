namespace Library.WebAPI.Authors.Features.AddAuthor;

public record AddAuthorResult(
    bool Success,
    string? Message = null,
    Guid? AuthorId = null) : Result(Success, Message);