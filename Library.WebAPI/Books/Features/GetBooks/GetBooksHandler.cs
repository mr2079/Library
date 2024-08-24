using Library.WebAPI.Books.Abstractions;

namespace Library.WebAPI.Books.Features.GetBooks;

public class GetBooksHandler(
    IBookRepository bookRepository)
    : IQueryHandler<GetBooksQuery, GetBooksResult>
{
    public async Task<GetBooksResult> Handle(
        GetBooksQuery query,
        CancellationToken cancellationToken)
    {
        try
        {
            var books = await bookRepository.GetAllAsync(
                null,
                null,
                true,
                query.Page,
                query.Take);

            if (books != null)
                return new GetBooksResult(
                    true,
                    null,
                    books.ToList());

            return new GetBooksResult(
                false,
                Error.GetFailed);
        }
        catch
        {
            return new GetBooksResult(
                false,
                Error.InternalServer);
        }
    }
}