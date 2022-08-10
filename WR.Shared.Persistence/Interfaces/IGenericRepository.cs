namespace WR.Shared.Persistence.Interfaces;

public interface IGenericRepository<TEntity>
    where TEntity : class, IDatabaseEntity
{
    public TEntity? GetFirstOrDefault(Func<TEntity, bool> predicate);

    public Task<TEntity?> GetFirstOrDefaultAsync(Guid key, CancellationToken token);

    public TEntity? GetFirstOrDefaultWithInclude(
        Func<TEntity, bool> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties);

    public IEnumerable<TEntity> GetAll();

    public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate);

    public IEnumerable<TEntity> GetAllWithInclude(
        params Expression<Func<TEntity, object>>[] includeProperties);

    public IEnumerable<TEntity> GetAllWithInclude(
        Func<TEntity, bool> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties);

    public Task<bool> CreateAsync(TEntity entity, CancellationToken token);

    public Task<bool> UpdateAsync(TEntity entity, CancellationToken token);

    public Task<bool> DeleteAsync(Guid key, CancellationToken token);
}