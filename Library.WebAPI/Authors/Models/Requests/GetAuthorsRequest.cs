namespace Library.WebAPI.Authors.Models.Requests;

public record GetAuthorsRequest(
    int? Page = null,
    int? Take = null);