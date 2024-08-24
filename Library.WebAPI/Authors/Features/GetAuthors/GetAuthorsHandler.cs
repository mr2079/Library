using Library.WebAPI.Authors.Abstractions;

namespace Library.WebAPI.Authors.Features.GetAuthors;

public class GetAuthorsHandler(
    IAuthorRepository authorRepository)
    : IQueryHandler<GetAuthorsQuery, GetAuthorsResult>
{
    public async Task<GetAuthorsResult> Handle(
        GetAuthorsQuery query,
        CancellationToken cancellationToken)
    {
        try
        {
            var authors = await authorRepository.GetAllAsync(
                null,
                query.Page,
                query.Take);

            if (authors != null)
                return new GetAuthorsResult(
                    true,
                    null,
                    authors.ToList());

            return new GetAuthorsResult(
                false,
                Error.GetFailed);
        }
        catch
        {
            return new GetAuthorsResult(
                false,
                Error.InternalServer);
        }
    }
}