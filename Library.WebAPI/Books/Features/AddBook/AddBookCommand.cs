namespace Library.WebAPI.Books.Features.AddBook;

public record AddBookCommand(
    Guid AuthorId,
    string Title,
    int PublishedYear)
    : ICommand<AddBookResult>;