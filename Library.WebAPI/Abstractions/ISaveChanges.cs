namespace Library.WebAPI.Abstractions;

public interface ISaveChanges
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}