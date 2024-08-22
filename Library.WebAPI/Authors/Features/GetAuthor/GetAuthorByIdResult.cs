namespace Library.WebAPI.Authors.Features.GetAuthor;

public record GetAuthorByIdResult(
    bool Success,
    string? Message = null,
    Author? Author = null) : Result(Success, Message);