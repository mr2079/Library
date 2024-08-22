using Library.WebAPI.Abstractions;
using Library.WebAPI.Books.Models;

namespace Library.WebAPI.Authors.Models;

public class Author : Entity
{
    public required string Name { get; set; }

    public ICollection<Book>? Books { get; set; }
}