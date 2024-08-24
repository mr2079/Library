using Library.WebAPI.Books.Abstractions;

namespace Library.WebAPI.Books.Features.GetBooksByAuthorId;

public class GetBooksByAuthorIdHandler(
    IBookRepository bookRepository)
    : IQueryHandler<GetBooksByAuthorIdQuery, GetBooksByAuthorIdResult>
{
    public async Task<GetBooksByAuthorIdResult> Handle(
        GetBooksByAuthorIdQuery query,
        CancellationToken cancellationToken)
    {
        try
        {
            var books = await bookRepository.GetAllAsync(
                b => Equals(b.AuthorId, query.AuthorId),
                query.Page,
                query.Take);

            if (books != null)
                return new GetBooksByAuthorIdResult(
                    true,
                    null,
                    books.ToList());

            return new GetBooksByAuthorIdResult(
                false,
                Error.GetFailed);
        }
        catch
        {
            return new GetBooksByAuthorIdResult(
                false,
                Error.InternalServer);
        }
    }
}