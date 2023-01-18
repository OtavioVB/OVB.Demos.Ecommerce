namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure.Repositories.Interfaces;

public interface IBaseRepository<TEntity>
    where TEntity : class
{
    public abstract Task AddEntityAsync(TEntity entity);
}
