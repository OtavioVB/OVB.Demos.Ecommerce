namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Interfaces;

public interface IMessengerSynchronizerService<TEntity>
    where TEntity : class
{
    public Task PublishMessengerToSynchronizeDatabase(TEntity account);
}
