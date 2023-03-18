using Microsoft.EntityFrameworkCore;
using Npgsql;
using OVB.Demos.Ecommerce.Libraries.Domain;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Base;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : DataTransferObjectBase
{
    protected readonly DataContext _dataContext;
    protected readonly IRetry _retry;

    protected BaseRepository(DataContext dataContext, IRetry retry)
    {
        _dataContext = dataContext;
        _retry = retry;
    }

    public Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        return _retry.TryRetry<Task, NpgsqlException, PostgresException>(() =>
        {
            return Task.FromResult(_dataContext.Set<TEntity>().AddAsync(entity, cancellationToken));
        });
    }

    public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        return _retry.TryRetry<Task, NpgsqlException, PostgresException>(() =>
        {
            return Task.FromResult(_dataContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken));
        });
    }

    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        return _retry.TryRetry<Task, NpgsqlException, PostgresException>(() =>
        {
            return Task.FromResult(() =>
            {
                _dataContext.Set<TEntity>().Remove(entity);
            });
        });
    }

    public Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        return _retry.TryRetry<Task, NpgsqlException, PostgresException>(() =>
        {
            return Task.FromResult(() =>
            {
                _dataContext.Set<TEntity>().RemoveRange(entities);
            });
        });
    }

    public Task<TEntity?> GetByIdentifierAsync(Guid identifier, CancellationToken cancellationToken)
    {
        return _retry.TryRetry<Task<TEntity?>, NpgsqlException, PostgresException>(() =>
        {
            return _dataContext.Set<TEntity>().Where(p => p.Identifier == identifier).FirstOrDefaultAsync();
        });
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        return _retry.TryRetry<Task, NpgsqlException, PostgresException>(() =>
        {
            return Task.FromResult(() =>
            {
                _dataContext.Set<TEntity>().Update(entity);
            });
        });
    }

    public Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        return _retry.TryRetry<Task, NpgsqlException, PostgresException>(() =>
        {
            return Task.FromResult(() =>
            {
                _dataContext.Set<TEntity>().UpdateRange(entities);
            });
        });
    }
}
