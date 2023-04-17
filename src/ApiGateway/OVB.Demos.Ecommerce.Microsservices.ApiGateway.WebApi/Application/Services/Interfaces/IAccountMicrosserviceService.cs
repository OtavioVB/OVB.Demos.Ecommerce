using OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.Application.Services.Inputs;

namespace OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.Application.Services.Interfaces;

public interface IAccountMicrosserviceService
{
    public Task<(bool HasDone, List<string> Notifications)> CreateUserAccountServiceAsync(CreateAccountMicrosserviceServiceInput input,
        CancellationToken cancellationToken);
}
