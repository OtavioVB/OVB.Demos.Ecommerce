using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories.Base.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories.Base;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : DataTransferObjectBase
{
    protected readonly DataContext _dataContext;
    protected readonly ITraceManager _traceManager;

    protected BaseRepository(DataContext dataContext, ITraceManager traceManager)
    {
        _dataContext = dataContext;
        _traceManager = traceManager;
    }

    public Task AddAsync(TEntity entity)
    {
        return Task.FromResult(_traceManager.StartTracing("Repository Add Async", ActivityKind.Internal, (activity) =>
        {
            return Task.FromResult(_dataContext.Set<TEntity>().AddAsync(entity));
        }, new Dictionary<string, string>()));
    }

    public Task AddRangeAsync(List<TEntity> entities)
    {
        return Task.FromResult(_traceManager.StartTracing("Repository Add Range Async", ActivityKind.Internal, (activity) =>
        {
            return Task.FromResult(_dataContext.Set<TEntity>().AddRangeAsync(entities));
        }, new Dictionary<string, string>()));
    }

    public Task DeleteAsync(TEntity entity)
    {
        return Task.FromResult(_dataContext.Set<TEntity>().Remove(entity));
    }

    public Task<TEntity?> GetByIdentifierAsync(Guid tenantIdentifier, Guid identifier)
    {
        return Task.FromResult(_dataContext.Set<TEntity>().Where(p => p.Identifier == identifier && p.TenantIdentifier == tenantIdentifier).FirstOrDefault());
    }
}
