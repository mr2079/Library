namespace Library.WebAPI.Books.Features.GetBooks;

public record GetBooksQuery(
    int? Page = null,
    int? Take = null)
    : IQuery<GetBooksResult>;