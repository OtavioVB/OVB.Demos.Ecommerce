using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Inputs.Models;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Interfaces;

public interface IMessengerSynchronizerService<TEntity>
    where TEntity : class
{
    public void PublishMessengerToSynchronizeDatabase(TEntity account);
}
