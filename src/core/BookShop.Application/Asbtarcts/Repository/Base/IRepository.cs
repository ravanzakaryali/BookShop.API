using BookShop.Application.Asbtarcts.Common;
using BookShop.Domain.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShop.Application.Asbtarcts.Repository.Base;

public interface IRepository<TDbContext, TEntity, TKey>
    where TEntity : BaseEntity<TKey>
    where TDbContext : IApplicationDbContext
    where TKey : IEquatable<TKey>
{
    DbSet<TEntity> Table { get; }

    Task<TEntity?> GetAsync(TKey id);

    Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool tracking = true,
        params string[] includes);
    Task<TResult?> GetWithSelectAsync<TResult>(
        Expression<Func<TEntity, TResult>> select,
        Expression<Func<TEntity, bool>>? predicate = null,
        bool tracking = true,
        params string[] includes);

    Task<IEnumerable<TEntity?>> GetAllAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool tracking = true,
        params string[] includes);

    Task<List<TEntity>> GetAllAsync<TOrderBy>(
        int page,
        int size,
        Expression<Func<TEntity, TOrderBy>> orderBy,
        Expression<Func<TEntity, bool>>? predicate = null,
        bool isOrderBy = true,
        bool tracking = true,
        params string[] includes);

    Task<List<TResult>> GetAllWithSelectAsync<TOrderBy, TResult>(
        Expression<Func<TEntity, TOrderBy>> orderBy,
        Expression<Func<TEntity, TResult>> select,
        Expression<Func<TEntity, bool>>? predicate = null,
        bool isOrderBy = true,
        bool tracking = true,
        params string[] includes);

    Task<List<TResult>> GetAllWithSelectAsync<TOrderBy, TResult>(
        int page,
        int size,
        Expression<Func<TEntity, TOrderBy>> orderBy,
        Expression<Func<TEntity, TResult>> select,
        Expression<Func<TEntity, bool>>? predicate = null,
        bool isOrderBy = true,
        bool tracking = true,
        params string[] includes);

    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}
