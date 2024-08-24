using Library.WebAPI.Authors.Models.Entities;

namespace Library.WebAPI.Authors.Features.GetAuthorById;

public record GetAuthorByIdResult(
    bool Success,
    string? Message = null,
    Author? Author = null) : Result(Success, Message);