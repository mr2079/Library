using Library.WebAPI.Authors.Abstractions;

namespace Library.WebAPI.Authors.Features.GetAuthor;

public class GetAuthorByIdHandler(
    IAuthorRepository authorRepository)
    : IQueryHandler<GetAuthorByIdQuery, GetAuthorByIdResult>
{
    public async Task<GetAuthorByIdResult> Handle(
        GetAuthorByIdQuery query,
        CancellationToken cancellationToken)
    {
        try
        {
            var author = await authorRepository.GetAsync(
                a => Equals(a.Id, query.Id));

            if (author != null)
                return new GetAuthorByIdResult(
                    true,
                    null,
                    author);

            return new GetAuthorByIdResult(
                false,
                Error.NotFound);
        }
        catch
        {
            return new GetAuthorByIdResult(
                false,
                Error.InternalServer);
        }
    }
}