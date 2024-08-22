namespace Library.WebAPI.Authors.Features.UpdateAuthor;

public record UpdateAuthorCommand(
    Guid Id,
    string Name)
    : ICommand<UpdateAuthorResult>;