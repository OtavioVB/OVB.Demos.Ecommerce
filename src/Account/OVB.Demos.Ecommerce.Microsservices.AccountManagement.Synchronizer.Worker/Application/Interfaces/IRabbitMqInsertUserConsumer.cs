using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Protobuffer;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Application.Interfaces;

public interface IRabbitMqInsertUserConsumer
{
    public Task CreateUserWithConsumerAsync();
}
