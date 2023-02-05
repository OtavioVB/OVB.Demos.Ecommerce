namespace OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.Repositories.Interfaces;

public interface IBaseRepository<TEntity>
    where TEntity : class
{
    public Task AddEntityAsync(TEntity entity);
}
