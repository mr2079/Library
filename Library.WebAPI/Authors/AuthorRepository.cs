using Library.WebAPI.Authors.Abstractions;
using Library.WebAPI.Persistence;

namespace Library.WebAPI.Authors;

public class AuthorRepository(
    LibraryDbContext context)
    : Repository<Author>(context), IAuthorRepository;