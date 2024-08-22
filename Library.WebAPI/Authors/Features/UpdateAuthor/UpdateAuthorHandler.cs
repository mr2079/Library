using Library.WebAPI.Authors.Abstractions;
using Mapster;

namespace Library.WebAPI.Authors.Features.UpdateAuthor;

public class UpdateAuthorHandler(
    IAuthorRepository authorRepository,
    ISaver saver)
    : ICommandHandler<UpdateAuthorCommand, UpdateAuthorResult>
{
    public async Task<UpdateAuthorResult> Handle(
        UpdateAuthorCommand command,
        CancellationToken cancellationToken)
    {
        var author = await authorRepository.GetAsync(
            a => Equals(a.Id, command.Id));

        if (author == null) 
            return new UpdateAuthorResult(
                false,
                Error.NotFound);

        command.Adapt(author);

        try
        {
            authorRepository.Update(author);
            var result = await saver.SaveChangesAsync(cancellationToken);

            if (result > 0)
                return new UpdateAuthorResult(true);

            return new UpdateAuthorResult(
                false,
                Error.UpdateFailed);
        }
        catch
        {
            return new UpdateAuthorResult(
                false,
                Error.InternalServer);
        }
    }
}