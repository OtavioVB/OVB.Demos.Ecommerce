namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Repository.Interfaces;

public interface IBaseRepository<TEntity>
    where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(List<TEntity> entity);
    void Delete(TEntity entity);
    void DeleteRange(List<TEntity> entity);
    void Update(TEntity entity);
    void UpdateRange(List<TEntity> entity);
    Task<List<TEntity>> GetByPaginationAsync(int index, int offset);
}