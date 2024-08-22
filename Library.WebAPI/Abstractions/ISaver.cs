namespace Library.WebAPI.Abstractions;

public interface ISaver
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}