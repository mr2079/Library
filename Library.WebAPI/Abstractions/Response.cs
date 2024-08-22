namespace Library.WebAPI.Abstractions;

public abstract record Response(
    bool Success,
    string? Message = null);