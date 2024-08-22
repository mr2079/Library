namespace Library.WebAPI.Authors.Features.AddAuthor;

public record AddAuthorCommand(
    string Name)
    : ICommand<AddAuthorResult>;