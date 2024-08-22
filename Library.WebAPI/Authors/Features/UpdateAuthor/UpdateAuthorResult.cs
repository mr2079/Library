namespace Library.WebAPI.Authors.Features.UpdateAuthor;

public record UpdateAuthorResult(
    bool Success,
    string? Message = null) : Result(Success, Message);