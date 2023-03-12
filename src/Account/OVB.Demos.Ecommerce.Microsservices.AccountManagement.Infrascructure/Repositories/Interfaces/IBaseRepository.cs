using OVB.Demos.Ecommerce.Libraries.Domain;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Interfaces;

public interface IBaseRepository<TEntity>
    where TEntity : DataTransferObjectBase
{
    public Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    public Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    public Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    public Task<TEntity?> GetByIdentifierAsync(Guid identifier, CancellationToken cancellationToken);
}
