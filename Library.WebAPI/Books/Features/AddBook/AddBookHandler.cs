using Library.WebAPI.Books.Abstractions;
using Mapster;

namespace Library.WebAPI.Books.Features.AddBook;

public class AddBookHandler(
    IBookRepository bookRepository,
    ISaver saver)
    : ICommandHandler<AddBookCommand, AddBookResult>
{
    public async Task<AddBookResult> Handle(
        AddBookCommand command,
        CancellationToken cancellationToken)
    {
        var book = command.Adapt<Book>();

        try
        {
            var bookId = bookRepository.Create(book);
            var result = await saver.SaveChangesAsync(cancellationToken);

            if (bookId != Guid.Empty && result > 0)
                return new AddBookResult(true, null, bookId);

            return new AddBookResult(
                false,
                Error.CreateFailed);
        }
        catch
        {
            return new AddBookResult(
                false,
                Error.InternalServer);
        }
    }
}