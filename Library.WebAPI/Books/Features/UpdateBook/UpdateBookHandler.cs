using Library.WebAPI.Books.Abstractions;
using Mapster;

namespace Library.WebAPI.Books.Features.UpdateBook;

public class UpdateBookHandler(
    IBookRepository bookRepository,
    ISaver saver)
    : ICommandHandler<UpdateBookCommand, UpdateBookResult>
{
    public async Task<UpdateBookResult> Handle(
        UpdateBookCommand command,
        CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetAsync(
            a => Equals(a.Id, command.Id));

        if (book == null) 
            return new UpdateBookResult(
                false,
                Error.NotFound);

        command.Adapt(book);

        try
        {
            bookRepository.Update(book);
            var result = await saver.SaveChangesAsync(cancellationToken);

            if (result > 0)
                return new UpdateBookResult(true);

            return new UpdateBookResult(
                false,
                Error.UpdateFailed);
        }
        catch
        {
            return new UpdateBookResult(
                false,
                Error.InternalServer);
        }
    }
}