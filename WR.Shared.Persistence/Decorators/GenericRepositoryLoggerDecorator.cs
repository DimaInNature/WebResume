namespace WR.Shared.Persistence.Decorators;

public class GenericRepositoryLoggerDecorator<TEntity> : IGenericRepository<TEntity>
    where TEntity : class, IDatabaseEntity
{
    private readonly ILogger<GenericRepositoryLoggerDecorator<TEntity>> _logger;

    private readonly IGenericRepository<TEntity> _repository;

    public GenericRepositoryLoggerDecorator(
        IGenericRepository<TEntity> repository,
        ILogger<GenericRepositoryLoggerDecorator<TEntity>> logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<TEntity?> GetFirstOrDefaultAsync(Guid key)
    {
        try
        {
            return await _repository.GetFirstOrDefaultAsync(key);
        }
        catch (Exception exception)
        {
            _logger.LogError(message: exception.Message);

            return default;
        }
    }

    public async Task<TEntity?> GetFirstOrDefaultAsync(
        Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            return await _repository.GetFirstOrDefaultAsync(predicate);
        }
        catch (Exception exception)
        {
            _logger.LogError(message: exception.Message);

            return default;
        }
    }

    public IEnumerable<TEntity> GetAll()
    {
        try
        {
            return _repository.GetAll();
        }
        catch (Exception exception)
        {
            _logger.LogError(message: exception.Message);

            return Array.Empty<TEntity>();
        }
    }

    public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate)
    {
        try
        {
            return _repository.GetAll(predicate);
        }
        catch (Exception exception)
        {
            _logger.LogError(message: exception.Message);

            return Array.Empty<TEntity>();
        }
    }

    public IEnumerable<TEntity> GetAllWithInclude(
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        try
        {
            return _repository.GetAllWithInclude(includeProperties);
        }
        catch (Exception exception)
        {
            _logger.LogError(message: exception.Message);

            return Array.Empty<TEntity>();
        }
    }

    public IEnumerable<TEntity> GetAllWithInclude(
        Func<TEntity, bool> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        try
        {
            return _repository.GetAllWithInclude(predicate, includeProperties);
        }
        catch (Exception exception)
        {
            _logger.LogError(message: exception.Message);

            return Array.Empty<TEntity>();
        }
    }

    public async Task<bool> CreateAsync(TEntity entity)
    {
        try
        {
            return await _repository.CreateAsync(entity);
        }
        catch (Exception exception)
        {
            _logger.LogError(message: exception.Message);

            return false;
        }
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        try
        {
            return await _repository.UpdateAsync(entity);
        }
        catch (Exception exception)
        {
            _logger.LogError(message: exception.Message);

            return false;
        }
    }

    public async Task<bool> DeleteAsync(Guid key)
    {
        try
        {
            return await _repository.DeleteAsync(key);
        }
        catch (Exception exception)
        {
            _logger.LogError(message: exception.Message);

            return false;
        }
    }
}