namespace Library.WebAPI.Books.Features.GetBookById;

public record GetBookByIdQuery(
    Guid Id)
    : IQuery<GetBookByIdResult>;