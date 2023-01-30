using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories.Base.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Domain.DataTransferObject;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories.Base;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : DataTransferObjectBase
{
    protected readonly DataContext _dataContext;

    protected BaseRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Task AddAsync(TEntity entity)
    {
        return Task.FromResult(_dataContext.Set<TEntity>().AddAsync(entity));
    }

    public Task AddRangeAsync(List<TEntity> entities)
    {
        return Task.FromResult(_dataContext.Set<TEntity>().AddRangeAsync(entities));
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
