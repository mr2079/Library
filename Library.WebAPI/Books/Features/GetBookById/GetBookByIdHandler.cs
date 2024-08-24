using Library.WebAPI.Books.Abstractions;

namespace Library.WebAPI.Books.Features.GetBookById;

public class GetBookByIdHandler(
    IBookRepository bookRepository)
    : IQueryHandler<GetBookByIdQuery, GetBookByIdResult>
{
    public async Task<GetBookByIdResult> Handle(
        GetBookByIdQuery query,
        CancellationToken cancellationToken)
    {
        try
        {
            var book = await bookRepository.GetAsync(
                a => Equals(a.Id, query.Id));

            if (book != null)
                return new GetBookByIdResult(
                    true,
                    null,
                    book);

            return new GetBookByIdResult(
                false,
                Error.NotFound);
        }
        catch
        {
            return new GetBookByIdResult(
                false,
                Error.InternalServer);
        }
    }
}