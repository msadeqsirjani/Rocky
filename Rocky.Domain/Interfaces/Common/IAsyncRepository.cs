﻿using Rocky.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Rocky.Domain.Interfaces.Common
{
    public interface IAsyncRepository<TEntity, in TKey> where TEntity : IBaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> SelectAsync();
        Task<IEnumerable<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> SelectAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order);
        Task<IEnumerable<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order, bool isTracking);
        Task<IEnumerable<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null, bool isTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, bool isTracking);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, bool isTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> FirstOrDefaultAsync(TKey id);
        Task<TEntity> AddAsync(TEntity entity, bool saveAutomatically = true);
        Task UpdateAsync(TEntity entity, bool saveAutomatically = true);
        Task DeleteAsync(TEntity entity, bool saveAutomatically = true);
        Task DeleteAsync(TKey id, bool saveAutomatically = true);
        Task DeleteAsync(Expression<Func<TEntity, bool>> expression, bool saveAutomatically = true);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExistsAsync(TKey id);
        Task SaveChangesAsync();
    }
}
