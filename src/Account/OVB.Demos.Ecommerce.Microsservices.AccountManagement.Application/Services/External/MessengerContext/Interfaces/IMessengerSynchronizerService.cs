using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Protobuffer;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.External.MessengerContext.Interfaces;

public interface IMessengerSynchronizerService
{
    public Task PublishMessageToBusToSynchronizeDatabaseWithInsert(UserProtobuffer user, Guid correlationIdentifier, Guid tenantIdentifier, string sourcePlatform,
        CancellationToken cancellationToken);
}
