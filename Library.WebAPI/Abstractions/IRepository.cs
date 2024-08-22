﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Library.WebAPI.Abstractions;

public interface IRepository<TEntity>
    where TEntity : Entity
{
    Task<IEnumerable<TEntity>?> GetAllAsync(
        Expression<Func<TEntity, bool>>? condition = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes = null,
        bool disableTracking = true,
        int? page = null,
        int? take = null);

    Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> condition,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes = null,
        bool disableTracking = false);

    Guid Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}