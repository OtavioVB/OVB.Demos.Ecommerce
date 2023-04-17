using Grpc.Core;
using GrpcAccountClient;
using OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.Application.Services.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.Application.Services.Inputs;
using OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.Application.Services.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.Application.Services;

public sealed class AccountMicrosserviceService : IAccountMicrosserviceService
{
    private readonly IAccountMicrosserviceConfiguration _accountMicrosserviceConfiguration;

    public AccountMicrosserviceService(
        IAccountMicrosserviceConfiguration accountMicrosserviceConfiguration)
    {
        _accountMicrosserviceConfiguration = accountMicrosserviceConfiguration;
    }

    public async Task<(bool HasDone, List<string> Notifications)> CreateUserAccountServiceAsync(CreateAccountMicrosserviceServiceInput input, 
        CancellationToken cancellationToken)
    {
        var clientCallResponse = await _accountMicrosserviceConfiguration.GetAccountClient().CreateUserAccountAsync(new CreateAccountInput()
        {
            ConfirmPassword = input.ConfirmPassword,
            CorrelationIdentifier = input.CorrelationIdentifier.ToString(),
            Email = input.Email,
            LastName = input.LastName,
            Name = input.Name,
            Password = input.Password,
            SourcePlatform = input.SourcePlatform,
            TenantIdentifier = input.TenantIdentifier.ToString(),
            Username = input.Username
        }, new CallOptions(cancellationToken: cancellationToken));

        throw new NotImplementedException();
    }
}
