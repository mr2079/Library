namespace Library.WebAPI.Authors.Models.Responses;

public record UpdateAuthorResponse(
    bool Success,
    string? Message = null) : Response(Success, Message);