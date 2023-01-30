using OVB.Demos.Ecommerce.Microsservices.Base.Domain.DataTransferObject;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories.Base.Interfaces;

public interface IBaseRepository<TEntity>
    where TEntity : DataTransferObjectBase
{
    public Task AddAsync(TEntity entity);
    public Task AddRangeAsync(List<TEntity> entities);
    public Task DeleteAsync(TEntity entity);
    public Task<TEntity?> GetByIdentifierAsync(Guid tenantIdentifier, Guid identifier);
}
