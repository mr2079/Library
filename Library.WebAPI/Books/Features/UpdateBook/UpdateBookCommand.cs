namespace Library.WebAPI.Books.Features.UpdateBook;

public record UpdateBookCommand(
    Guid Id,
    string Title,
    int PublishedYear)
    : ICommand<UpdateBookResult>;