namespace Library.WebAPI.Controllers.Authors;

public record GetAuthorsRequest(
    int? Page = null,
    int? Take = null);