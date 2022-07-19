﻿namespace WR.Shared.Persistence.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class, IDatabaseEntity
{
    private readonly DbContext _context;

    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(DbContext context) =>
        (_context, _dbSet) = (context, _dbSet = context.Set<TEntity>());

    public async Task<TEntity?> GetFirstOrDefaultAsync(Guid key) =>
        await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate: entity => entity.Id == key);

    public async Task<TEntity?> GetFirstOrDefaultAsync(
        Expression<Func<TEntity, bool>> predicate) =>
        await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);

    public IEnumerable<TEntity> GetAll() => _dbSet.AsNoTracking();

    public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate) =>
        _dbSet.AsNoTracking().Where(predicate);

    public IEnumerable<TEntity> GetAllWithInclude(
        params Expression<Func<TEntity, object>>[] includeProperties) =>
        Include(includeProperties);

    public IEnumerable<TEntity> GetAllWithInclude(
        Func<TEntity, bool> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties) =>
        Include(includeProperties).Where(predicate);

    public async Task<bool> CreateAsync(TEntity entity)
    {
        if (entity is default(TEntity) or null) return false;

        await _dbSet.AddAsync(entity);

        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        if (entity is default(TEntity) or null) return false;

        _dbSet.Attach(entity);

        _context.Entry(entity).State = EntityState.Modified;

        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> DeleteAsync(Guid key)
    {
        if (key == Guid.Empty) return false;

        TEntity? entity = await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(predicate: entity => entity.Id == key);

        if (entity is default(TEntity) or null) return false;

        _dbSet.Remove(entity);

        return await _context.SaveChangesAsync() == 1;
    }

    private IQueryable<TEntity> Include(
        params Expression<Func<TEntity, object>>[] includeProperties) =>
        includeProperties.Aggregate(
            seed: _dbSet.AsNoTracking(),
            func: (current, includeProperty) =>
                current.Include(navigationPropertyPath: includeProperty));
}