namespace Library.WebAPI.Books.Models.Requests;

public record GetBooksRequest(
    int? Page = null,
    int? Take = null);