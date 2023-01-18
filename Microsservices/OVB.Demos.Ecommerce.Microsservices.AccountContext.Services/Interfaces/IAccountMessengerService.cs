using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Entities.Base;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Interfaces;

public interface IAccountMessengerService
{
    public void SendMessageAboutAccountCreatedUsingMessenger(AccountBase account);
}
