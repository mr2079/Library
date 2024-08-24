namespace Library.WebAPI.Authors.Models.Responses;

public record GetAuthorByIdResponse(
    bool Success,
    string? Message = null,
    Author? Author = null) : Response(Success, Message);