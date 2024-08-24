using Library.WebAPI.Authors.Abstractions;
using Library.WebAPI.Authors.Models.Entities;
using Mapster;

namespace Library.WebAPI.Authors.Features.AddAuthor;

public class AddAuthorHandler(
    IAuthorRepository authorRepository,
    ISaver saver)
    : ICommandHandler<AddAuthorCommand, AddAuthorResult>
{
    public async Task<AddAuthorResult> Handle(
        AddAuthorCommand command,
        CancellationToken cancellationToken)
    {
        var author = command.Adapt<Author>();

        try
        {
            var authorId = authorRepository.Create(author);
            var result = await saver.SaveChangesAsync(cancellationToken);

            if (authorId != Guid.Empty && result > 0)
                return new AddAuthorResult(true, null, authorId);

            return new AddAuthorResult(
                false,
                Error.CreateFailed);
        }
        catch
        {
            return new AddAuthorResult(
                false,
                Error.InternalServer);
        }
    }
}