using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.Repository.Base;
using BookShop.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Drawing;
using System.Linq.Expressions;

namespace BookShop.Application.Contracts.Repository.Base;

public class Repository<TDbContext, TEntity, TKey> : IRepository<TDbContext, TEntity, TKey>
    where TEntity : BaseEntity<TKey>
    where TDbContext : IApplicationDbContext
    where TKey : IEquatable<TKey>
{
    private readonly TDbContext _context;

    public Repository(TDbContext context)
    {
        _context = context;
    }

    public DbSet<TEntity> Table
    {
        get
        {
            DbSet<TEntity> table = Table;
            return table;
        }
    }

    public async Task<TEntity?> GetAsync(TKey id)
        => await Table.FindAsync(id);

    public async Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool tracking = true,
        params string[] includes)
    {
        IQueryable<TEntity> query = GetQuery(includes);
        if (!tracking)
            query = Table.AsNoTracking();
        return predicate is null
            ? await query.FirstOrDefaultAsync()
            : await query.Where(predicate).FirstOrDefaultAsync();
    }

    public async Task<TResult?> GetWithSelectAsync<TResult>(
        Expression<Func<TEntity, TResult>> select,
        Expression<Func<TEntity, bool>>? predicate = null,
        bool tracking = true,
        params string[] includes)
    {
        IQueryable<TEntity> query = GetQuery(includes);
        if (!tracking)
            query = Table.AsNoTracking();
        return predicate is null
           ? await query.Select(select).FirstOrDefaultAsync()
           : await query.Where(predicate).Select(select).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TEntity?>> GetAllAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool tracking = true,
        params string[] includes)
    {
        IQueryable<TEntity> query = GetQuery(includes);
        if (!tracking)
            query = Table.AsNoTracking();
        return predicate is null
            ? await query.ToListAsync()
            : await query.Where(predicate).ToListAsync();
    }

    public async Task<List<TEntity>> GetAllAsync<TOrderBy>(
      int page,
      int size,
      Expression<Func<TEntity, TOrderBy>> orderBy,
      Expression<Func<TEntity, bool>>? predicate = null,
      bool isOrderBy = true,
      bool tracking = true,
      params string[] includes)
    {
        IQueryable<TEntity> query = GetQuery(includes);
        if (!tracking)
            query = Table.AsNoTracking();
        return predicate is null
            ? isOrderBy
                ? await query.Skip((page - 1) * size).Take(size).ToListAsync()
                : await query.OrderByDescending(orderBy).Skip((page - 1) * size).Take(size).ToListAsync()
            : isOrderBy
                ? await query.Where(predicate).Skip((page - 1) * size).Take(size).ToListAsync()
                : await query.Where(predicate).OrderByDescending(orderBy).Skip((page - 1) * size).Take(size).ToListAsync();
    }

    public async Task<List<TResult>> GetAllWithSelectAsync<TOrderBy, TResult>(
        Expression<Func<TEntity, TOrderBy>> orderBy,
        Expression<Func<TEntity, TResult>> select,
        Expression<Func<TEntity, bool>>? predicate = null,
        bool isOrderBy = true,
        bool tracking = true,
        params string[] includes)
    {
        IQueryable<TEntity> query = GetQuery(includes);
        if (!tracking)
            query = Table.AsNoTracking();
        return predicate is null
            ? isOrderBy
                ? await query.Select(select).ToListAsync()
                : await query.OrderByDescending(orderBy).Select(select).ToListAsync()
            : isOrderBy
                ? await query.Where(predicate).Select(select).ToListAsync()
                : await query.Where(predicate).OrderByDescending(orderBy).Select(select).ToListAsync();
    }

    public async Task<List<TResult>> GetAllWithSelectAsync<TOrderBy, TResult>(
        int page,
        int size,
        Expression<Func<TEntity, TOrderBy>> orderBy,
        Expression<Func<TEntity, TResult>> select,
        Expression<Func<TEntity, bool>>? predicate = null,
        bool isOrderBy = true,
        bool tracking = true,
        params string[] includes)
    {
        IQueryable<TEntity> query = GetQuery(includes);
        if (!tracking)
            query = Table.AsNoTracking();
        return predicate is null
            ? isOrderBy
                ? await query.Skip((page - 1) * size).Take(size).Select(select).ToListAsync()
                : await query.OrderByDescending(orderBy).Skip((page - 1) * size).Take(size).Select(select).ToListAsync()
            : isOrderBy
                ? await query.Where(predicate).Skip((page - 1) * size).Take(size).Select(select).ToListAsync()
                : await query.Where(predicate).OrderByDescending(orderBy).Skip((page - 1) * size).Take(size).Select(select).ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        EntityEntry newEntity = await Table.AddAsync(entity);
        newEntity.State = EntityState.Added;
    }
    public void Remove(TEntity entity)
    {
        EntityEntry newEntity = Table.Remove(entity);
        newEntity.State = EntityState.Deleted;
    }


    public void Update(TEntity entity)
    {
        EntityEntry newEntity = Table.Update(entity);
        newEntity.State = EntityState.Modified;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    private IQueryable<TEntity> GetQuery(params string[] includes)
    {
        IQueryable<TEntity> query = Table.AsQueryable();
        if (includes != null)
        {
            foreach (string item in includes)
            {
                query = query.Include(item);
            }
        }
        return query;
    }
}
