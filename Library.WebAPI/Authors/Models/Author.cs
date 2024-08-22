﻿namespace Library.WebAPI.Authors.Models;

public class Author : Entity
{
    public required string Name { get; set; }

    public ICollection<Book>? Books { get; set; }
}