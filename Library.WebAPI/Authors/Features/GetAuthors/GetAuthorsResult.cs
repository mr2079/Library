namespace Library.WebAPI.Authors.Features.GetAuthors;

public record GetAuthorsResult(
    bool Success,
    string? Message = null,
    IReadOnlyList<Author>? Authors = null) : Result(Success, Message);