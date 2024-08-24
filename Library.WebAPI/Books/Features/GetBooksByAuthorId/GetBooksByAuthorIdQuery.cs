namespace Library.WebAPI.Books.Features.GetBooksByAuthorId;

public record GetBooksByAuthorIdQuery(
    Guid AuthorId,
    int? Page = null,
    int? Take = null)
    : IQuery<GetBooksByAuthorIdResult>;