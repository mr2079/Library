namespace Library.WebAPI.Books.Models.DTOs;

public record BookDto(
    Guid Id,
    string Title,
    int PublishedYear);