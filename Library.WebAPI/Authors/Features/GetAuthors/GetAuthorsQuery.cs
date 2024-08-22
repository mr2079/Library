namespace Library.WebAPI.Authors.Features.GetAuthors;

public record GetAuthorsQuery(
    int? Page = null,
    int? Take = null)
    : IQuery<GetAuthorsResult>;