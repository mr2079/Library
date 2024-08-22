namespace Library.WebAPI.Abstractions;

public abstract record Result(
    bool Success,
    string? Message = null);