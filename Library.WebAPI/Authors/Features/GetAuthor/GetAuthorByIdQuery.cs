namespace Library.WebAPI.Authors.Features.GetAuthor;

public record GetAuthorByIdQuery(
    Guid Id)
    : IQuery<GetAuthorByIdResult>;