using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Library.WebAPI.Persistence;

public class Repository<TEntity>
    : IRepository<TEntity>
    where TEntity : Entity
{
    protected int DefaultTake = 10;

    protected readonly LibraryDbContext Context;
    protected readonly DbSet<TEntity> Entity;

    public Repository(LibraryDbContext context)
    {
        Context = context;
        Entity = Context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>?> GetAllAsync(
        Expression<Func<TEntity, bool>>? condition = null,
        int? page = null,
        int? take = null)
    {
        var query = Entity.AsQueryable();

        query = query.AsNoTracking();

        if (condition != null) query = query.Where(condition);

        if (page is null or 0) return await query.ToListAsync();

        if (take is 0) take = DefaultTake;
        var skip = (page - 1) * take;

        query = query.Skip((int)skip!).Take((int)take!);

        return await query.ToListAsync();
    }

    public async Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> condition)
    {
        var query = Entity.AsQueryable();

        query = query.AsNoTracking();

        query = query.Where(condition);

        return await query.SingleOrDefaultAsync();
    }

    public Guid Create(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        return entity.Id;
    }

    public void Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        entity.IsDeleted = true;
        Context.Entry(entity).State = EntityState.Modified;
    }
}