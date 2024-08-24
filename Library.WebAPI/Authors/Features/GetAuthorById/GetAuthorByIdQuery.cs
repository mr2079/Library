namespace Library.WebAPI.Authors.Features.GetAuthorById;

public record GetAuthorByIdQuery(
    Guid Id)
    : IQuery<GetAuthorByIdResult>;