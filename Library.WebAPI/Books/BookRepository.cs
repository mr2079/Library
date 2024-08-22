﻿using Library.WebAPI.Books.Abstractions;
using Library.WebAPI.Persistence;

namespace Library.WebAPI.Books;

public class BookRepository(
    LibraryDbContext context)
    : Repository<Book>(context), IBookRepository;